using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace cse3902.RoomClasses
{
    public class MapLoader
    {
        private readonly string xmlFilePath;

        public MapLoader(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;
        }

        public List<List<int>> LoadMap()
        {
            List<List<int>> tileIds = new List<List<int>>();

            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);

                foreach (XElement settingElement in doc.Descendants("Setting"))
                {
                    if (settingElement.Attribute("name")?.Value == "TileIds")
                    {
                        foreach (XElement rowElement in settingElement.Value.Split('\n').Select(line => new XElement("Row", line)).ToList())
                        {
                            List<int> row = rowElement.Value.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(value => int.Parse(value))
                                .ToList();

                            tileIds.Add(row);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading map: {e.Message}");
            }

            return tileIds;
        }

    }
}
