namespace Assessment.Shared
{
    public interface IZeroTrustDataService
    {
        Task<ZeroTrustData?> GetZeroTrustDataAsync();
    }
}