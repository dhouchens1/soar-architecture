using Refactoring.Interfaces;

namespace Refactoring.Strategies
{
    public class CarTravelStrategy : ITravelStrategy
    {
        public TimeSpan CalculateTravelTime(double miles)
        {
            return TimeSpan.FromHours(miles / 60);
        }
    }
}