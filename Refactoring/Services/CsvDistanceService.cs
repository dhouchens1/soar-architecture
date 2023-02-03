using Microsoft.VisualBasic.FileIO;
using Refactoring.Interfaces;

namespace Refactoring.Services
{
    public class CsvDistanceService : IDistanceService
    {
        public Task<double> GetDistanceInMiles(string origin, string destination)
        {
            var path = "Data/Distances.csv";
            var parser = new TextFieldParser(path)
            {
                HasFieldsEnclosedInQuotes = true,
                Delimiters = new[] { "," },
            };

            while (!parser.EndOfData)
            {
                var columns = parser.ReadFields();
                if (columns[0] == origin && columns[1] == destination)
                {
                    return Task.FromResult(double.Parse(columns[2]));
                }
            }

            return Task.FromResult(0d);
        }
    }
}
