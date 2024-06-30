using Newtonsoft.Json.Linq;
using Scrap_Google_Search_Console.Interfaces;
using Scrap_Google_Search_Console.Utils;

namespace Scrap_Google_Search_Console.Implements
{
    public class Utils : IUtils
    {
        public List<(double lat, double lng)> GetGridLocation(double minLat, double minLng, double maxLat, double maxLng, double step)
        {
            var locations = new List<(double, double)>();
            for (double lat = minLat; lat <= maxLat; lat += step)
            {
                for (double lng = minLng; lng <= maxLng; lng += step)
                {
                    locations.Add((lat, lng));
                }
            }
            return locations;
        }

        public string GetState(JToken addressComponents)
        {
            if (addressComponents == null)
            {
                return "Unknown";
            }
            
            foreach (var component in addressComponents.First())
            {
                if (component != null)
                {
                    try
                    {
                        AustraliaStates states = new AustraliaStates();


                        string shortenedState = states.GetStatesList().
                            FirstOrDefault(shortState => component.ToString().Contains(shortState));

                        if (string.IsNullOrEmpty(shortenedState))
                        {
                            shortenedState = states.GetStatesListShortened().
                                FirstOrDefault(shortState => component.ToString().Contains(shortState));
                        }


                        if (!string.IsNullOrEmpty(shortenedState))
                        {
                            return shortenedState;
                        }
                        else
                        {
                            return "Unknown";
                        }

                    }
                    catch (Exception)
                    {
                        return "Unknown";
                    }
                }
                else
                {
                    return "Unknown";
                }
            }
            return "Unknown";
        }
    }
}
