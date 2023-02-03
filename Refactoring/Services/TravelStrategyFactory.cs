using Refactoring.Enums;
using Refactoring.Interfaces;
using Refactoring.Strategies;

namespace Refactoring.Services
{
    public class TravelStrategyFactory : ITravelStrategyFactory
    {
        public ITravelStrategy ResolveStrategy(ModeOfTravel modeOfTravel)
        {
            return modeOfTravel switch
            {
                ModeOfTravel.Car => new CarTravelStrategy(),
                ModeOfTravel.Bike => new BikeTravelStrategy(),
                ModeOfTravel.Running => new RunningTravelStrategy(),
                ModeOfTravel.Walking => new WalkingTravelStrategy(),
                _ => throw new ArgumentException($"Travel mode of {modeOfTravel} is not supported."),
            };
        }
    }
}
