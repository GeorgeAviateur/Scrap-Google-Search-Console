using System.Xml;
using Scrap_Google_Search_Console.Interfaces;
using Scrap_Google_Search_Console.Utils;

namespace Scrap_Google_Search_Console.Implements
{
    public class CreateXML : IManageXML
    {


        public void Create(List<Dictionary<string, string>> stations)
        {
            XMLParams parameter = new();
            using XmlWriter writer = XmlWriter.Create(parameter.GetFileName(), new XmlWriterSettings { Indent = true });

            writer.WriteStartDocument();
            writer.WriteStartElement(parameter.GetTitle());

            foreach (var station in stations)
            {
                writer.WriteStartElement(parameter.GetheaderTag());

                writer.WriteElementString("Name", station["name"]);
                writer.WriteElementString("Address", station["formatted_address"]);
                writer.WriteElementString("State", station["state"]);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }
}
