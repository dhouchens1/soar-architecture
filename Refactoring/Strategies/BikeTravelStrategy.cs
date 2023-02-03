using Refactoring.Interfaces;

namespace Refactoring.Strategies
{
    public class BikeTravelStrategy : ITravelStrategy
    {
        public TimeSpan CalculateTravelTime(double miles)
        {
            return TimeSpan.FromHours(miles / 15);
        }
    }
}