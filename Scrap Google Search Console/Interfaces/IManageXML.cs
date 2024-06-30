using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrap_Google_Search_Console.Interfaces
{
    public interface IManageXML
    {
        void Create(List<Dictionary<string, string>> stations);
    }
}
