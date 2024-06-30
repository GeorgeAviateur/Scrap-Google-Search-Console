using Newtonsoft.Json.Linq;

namespace Scrap_Google_Search_Console.Interfaces
{
    internal interface IUtils
    {
        List<(double lat, double lng)> GetGridLocation(double minLat, double minLng, double maxLat, double maxLng, double step);
        string GetState(JToken addressComponent);
    }
}
