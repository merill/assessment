namespace Assessment.Shared
{
    public class ZeroTrustData
    {
        public ZeroTrustData() 
        {
            AppProtectionPolicy = new AppProtectionPolicy();
        }
        public AppProtectionPolicy AppProtectionPolicy { get; set; }
    }
}
