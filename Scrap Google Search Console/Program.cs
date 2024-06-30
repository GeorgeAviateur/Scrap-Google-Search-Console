using Scrap_Google_Search_Console.Implements;
class Program
{ 
    /// <summary>
    /// This small console application consumes an API from Google Called API Places and collects The information needed.
    /// The outcome for this is scrapping places from google maps
    /// 
    /// To change the parameters to search go to Utils/APIParams.cs
    /// 
    /// PURPOSE:
    /// The purpose of this application is just for academic purposes, studying here Interfaces, API Consumption, JSON requests, and an apporach to factory pattern
    /// 
    /// This project could be used as a Service in a server, or being modified to be a rest API.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    static async Task Main()
    {
        CreateXML manageXmL = new();
        ApiPlacesFunctions places = new();
        //places to look up for
        var allStations = await places.FillPlaces("gas_station");
        // Save the results to XML
        manageXmL.Create(allStations);
    }
}