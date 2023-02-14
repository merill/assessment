using Microsoft.Graph;

namespace Assessment.Shared
{
    public class ZeroTrustDataService : IZeroTrustDataService
    {
        private readonly GraphServiceClient client;
        private ZeroTrustData zeroTrustData = new ZeroTrustData();

        public ZeroTrustDataService(GraphServiceClient client)
        {
            this.client = client;
        }

        public async Task<ZeroTrustData?> GetZeroTrustDataAsync()
        {
            await DoAppProtectionPolicyCheck();

            return zeroTrustData;
        }

        private async Task DoAppProtectionPolicyCheck()
        {
            var request = client.DeviceAppManagement.ManagedAppPolicies.Request();
            var appProtectionPolicies = await request.GetAsync();

            zeroTrustData.AppProtectionPolicy = new AppProtectionPolicy();
            if(appProtectionPolicies != null)
            {
                zeroTrustData.AppProtectionPolicy.HasIosPolicy = appProtectionPolicies.Any(p => p.ODataType == "#microsoft.graph.iosManagedAppProtection");
                zeroTrustData.AppProtectionPolicy.HasAndroidPolicy = appProtectionPolicies.Any(p => p.ODataType == "#microsoft.graph.androidManagedAppProtection");
            }
        }
    }
}
