namespace Refactoring.Interfaces
{
    public interface IDistanceService
    {
        Task<double> GetDistanceInMiles(string origin, string destination);
    }
}
