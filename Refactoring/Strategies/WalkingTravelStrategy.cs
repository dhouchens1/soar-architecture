using Refactoring.Interfaces;

namespace Refactoring.Strategies
{
    public class WalkingTravelStrategy : ITravelStrategy
    {
        public TimeSpan CalculateTravelTime(double miles)
        {
            return TimeSpan.FromHours(miles / 3);
        }
    }
}