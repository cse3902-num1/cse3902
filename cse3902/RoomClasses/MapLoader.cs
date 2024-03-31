using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using System.Reflection;

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

            // Get the directory where the solution file resides
              string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            //string solutionDir = Directory.GetCurrentDirectory();

            // Define the relative path to the XML file
            string relativePath = xmlFilePath;

            // Combine to get the full path
            string filePath = Path.Combine(solutionDir, relativePath);
            
            XmlDocument doc = new XmlDocument();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                doc.Load(fs);
            }

            // Find the Setting node
            XmlNode settingNode = doc.SelectSingleNode("/Settings/Setting");

            // Get the inner text containing the matrix
            string matrixText = settingNode.InnerText.Trim();

            // Split the matrix text into rows
            string[] rows = matrixText.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // Iterate through rows and columns to fill the matrix
            foreach (string row in rows)
            {
                List<int> newRow = new List<int>();
                string[] values = row.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string value in values)
                {
                    newRow.Add(int.Parse(value));
                }
                tileIds.Add(newRow);
            }

            return tileIds;
        }

    }
}
