using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic.FileIO;
using Refactoring.Enums;

namespace Refactoring.Components
{
    public class TravelCalculatorBase : ComponentBase
    {
        //[Inject]
        //public IDistanceService DistanceService { get; set; }

        //[Inject]
        //public ITravelStrategyFactory TravelStrategyFactory { get; set; }

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

            var miles = 0d;
            var path = "Data/Distances.csv";
            var parser = new TextFieldParser(path)
            {
                HasFieldsEnclosedInQuotes = true,
                Delimiters = new[] { "," },
            };

            while (!parser.EndOfData)
            {
                var columns = parser.ReadFields();
                if (columns[0] == SelectedOrigin && columns[1] == SelectedDestination)
                {
                    miles = double.Parse(columns[2]);
                }
            }

            if (SelectedModeOfTravel == ModeOfTravel.Car)
            {
                CalculatedTravelTime = TimeSpan.FromHours(miles / 60);
            }
            else if (SelectedModeOfTravel == ModeOfTravel.Bike)
            {
                CalculatedTravelTime = TimeSpan.FromHours(miles / 15);
            }
            else if (SelectedModeOfTravel == ModeOfTravel.Running)
            {
                CalculatedTravelTime = TimeSpan.FromHours(miles / 7);
            }
            else if (SelectedModeOfTravel == ModeOfTravel.Walking)
            {
                CalculatedTravelTime = TimeSpan.FromHours(miles / 3);
            }
        }
    }
}
