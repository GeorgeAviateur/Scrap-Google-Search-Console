using System.Reflection.Metadata;

namespace Scrap_Google_Search_Console.Utils
{
    /// <summary>
    /// These classes are used to set the project up.
    /// APIparams stablishes parameters to the API
    /// </summary>
    public class APIparams
    {

        public string? apiKey;
        public (double lat, double lng) location;
        public int radius;
        public string? elementToSearch;
        public int limitRows;
        public double minLat;
        public double minLng;
        public double maxLat;
        public double maxLng;
        public double steps;
        public APIparams() {
            FillApiParams();
        }
        private void FillApiParams()
        {
            apiKey = "";//  put here your api key
            radius = 100000; //radius in meters
            elementToSearch = "gas_station"; // this is not in use. You can modify it
            limitRows = 10;//This parameter stablish the amount of requests. remember that google has quotas by usage.

            // Rough bounding box of Melbourne with 1 degree step. You could change the range for an enormous range
            // When the range is bigger, it'll be divided into parts (steps) 
            // When the range is bigger, you must have in consideration that the fewer step and radius the more consumption it'll take and more information will be collected
            minLat = -38.00;
            minLng  = 144.00;
            maxLat = -37.00;
            maxLng = 145.0;
            steps = 1.0;

        }
        public void SetSearch(string type) {
            elementToSearch = type;
        }
    }
    /// <summary>
    /// These classes are used to set the project up.
    /// XMLParams stablishes parameters to the XML document
    /// </summary>
    public class XMLParams {
        private readonly string fileName="";
        private readonly string title ="ServiceStation";
        private readonly string headerTag = "ServiceStation";
        public XMLParams()
        {
            fileName = "C:\\Users\\public\\Downloads\\ServiceStations.xml";
        }
        public string GetFileName() { return fileName; }
        public string GetTitle() { return title; }
        public string GetheaderTag() { return headerTag; }
    }
    /// <summary>
    /// These classes are used to set the project up.
    /// AustraliaStates stablishes states in Australia, so when a JSon message contains the state, we could manipulate the data easily
    /// </summary>
    public class AustraliaStates {
        private readonly string[] statesList = { "New South Wales", "Victoria", "Queensland", "South Australia", "Western Australia", "Tasmania", "Australian Capital Territory", "Northern Territory" };
        private readonly string[] statesListShortened = { "NSW", "VIC", "QLD", "SA", "WA", "TAS", "ACT", "NT" };

        public string[] GetStatesList() { return statesList; }
        public string[] GetStatesListShortened() { return statesListShortened; }
    }
}
