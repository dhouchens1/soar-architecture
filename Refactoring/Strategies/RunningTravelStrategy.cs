using Refactoring.Interfaces;

namespace Refactoring.Strategies
{
    public class RunningTravelStrategy : ITravelStrategy
    {
        public TimeSpan CalculateTravelTime(double miles)
        {
            return TimeSpan.FromHours(miles / 7);
        }
    }
}