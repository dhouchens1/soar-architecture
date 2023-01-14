using Refactoring.Interfaces;

namespace Refactoring.Services
{
    public class MapQuestDistanceService : IDistanceService
    {
        public async Task<double> GetDistanceInMiles(string origin, string destination)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"http://www.mapquestapi.com/directions/v2/route?key=c95lmEGUNwPkyQA2fj5kbmUGW9vkdGcy&from={origin}&to={destination}");

            var content = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializerExtensions.DeserializeAnonymousType(
                content,
                new
                {
                    route = new
                    {
                        distance = 0d,
                    },
                });

            return responseObject.route.distance;
        }
    }
}
