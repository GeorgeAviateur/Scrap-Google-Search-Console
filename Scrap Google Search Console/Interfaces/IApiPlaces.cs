using Scrap_Google_Search_Console.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrap_Google_Search_Console.Interfaces
{
    public interface IApiPlaces
    {
        
        public Task<List<Dictionary<string, string>>> GetServiceStationsAsync(APIparams apiParam);
        public Task<List<Dictionary<string, string>>> FillPlaces(string elementToSearch);
    }
}
