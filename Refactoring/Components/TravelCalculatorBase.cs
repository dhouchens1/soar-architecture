using Microsoft.AspNetCore.Components;
using Refactoring.Enums;
using Refactoring.Interfaces;

namespace Refactoring.Components
{
    public class TravelCalculatorBase : ComponentBase
    {
        [Inject]
        public IDistanceService DistanceService { get; set; }

        [Inject]
        public ITravelStrategyFactory TravelStrategyFactory { get; set; }

        protected string SelectedOrigin { get; set; }

        protected string SelectedDestination { get; set; }

        protected ModeOfTravel? SelectedModeOfTravel { get; set; }

        protected TimeSpan CalculatedTravelTime { get; private set; }

        protected async Task CalculateTravelTime()
        {
            if (string.IsNullOrEmpty(SelectedOrigin) || string.IsNullOrEmpty(SelectedDestination) || SelectedModeOfTravel == null)
            {
                throw new Exception("All three inputs must have values!");
            }

            var miles = await DistanceService.GetDistanceInMiles(SelectedOrigin, SelectedDestination);

            CalculatedTravelTime = TravelStrategyFactory.ResolveStrategy(SelectedModeOfTravel.Value)
                .CalculateTravelTime(miles);
        }
    }
}
