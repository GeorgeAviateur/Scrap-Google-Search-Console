using Newtonsoft.Json.Linq;
using Scrap_Google_Search_Console.Interfaces;
using Scrap_Google_Search_Console.Utils;

namespace Scrap_Google_Search_Console.Implements
{
    public class ApiPlacesFunctions : IApiPlaces
    {
        /// <summary>
        /// This method is the core of the project. In here the loctions are gathered, dividing a map into many sections.
        /// Filling the results of the API on a dictionary
        /// </summary>
        /// <param name="elementToSearch"></param>
        /// <returns></returns>
        public async Task<List<Dictionary<string, string>>> FillPlaces(string elementToSearch)
        {
            List<Dictionary<string, string>> allStations = new();
            Utils util = new();
            APIparams parameters = new APIparams();
            var locations = util.GetGridLocation( parameters.minLat,parameters.minLng, parameters.maxLat, parameters.maxLng,parameters.steps); 

            
            parameters.SetSearch(elementToSearch);
            int numberResults = 0;
            foreach (var location in locations)
            {
                if (numberResults<=parameters.limitRows)
                {
                    parameters.location = location;
                    var stations = await GetServiceStationsAsync(parameters);
                    allStations.AddRange(stations);
                    numberResults++;
                }
                else { break; }
            }
            return allStations;
        }
        /// <summary>
        /// This method calls asynchronically the Uri and consume the JSON response
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="location"></param>
        /// <param name="radius"></param>
        /// <param name="elementToSearch"></param>
        /// <returns></returns>
        /// 
        
        public async Task<List<Dictionary<string, string>>> GetServiceStationsAsync(APIparams param)
        {
            var results = new List<Dictionary<string, string>>();
            string? nextPageToken = null;
            Utils util = new();
            do
            {
                string requestUri = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={param.location.lat},{param.location.lng}&radius={param.radius}&type={param.elementToSearch}&key={param.apiKey}";
                if (!string.IsNullOrEmpty(nextPageToken))
                {
                    requestUri += $"&pagetoken={nextPageToken}";
                    await Task.Delay(2000); // Necessary delay for next_page_token to become active
                }

                using HttpClient client = new ();
                HttpResponseMessage response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);
                results.AddRange(from result in json["results"]
                                 let station = new Dictionary<string, string>
                                 {
                                     { "name", result["name"]==null ? "" : result["name"] !.ToString() },
                                     { "formatted_address", result["vicinity"]==null?"" : result["vicinity"]!.ToString() },
                                     { "state", util.GetState(result["plus_code"]==null?"" : result["plus_code"] !) }
                                 }
                                 select station);
                nextPageToken = json.Value<string>("next_page_token");
            } while (!string.IsNullOrEmpty(nextPageToken));

            return results;
        }
    }
}
