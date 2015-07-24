using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using SuperMario;

namespace LevelGenerator
{
    class Program
    {
        public struct Item
        {
            public string Type;
            public string Version;
            public int GridWidth;
            public int GridHeight;

            public Item(string type, string version = null, int gridWidth = 1, int gridHeight = 1)
            {
                Type = type;
                Version = version ?? string.Empty;
                GridWidth = gridWidth;
                GridHeight = gridHeight;
            }
        }

        public struct Section
        {
            public int GridX;
            public int GridY;
            public int Column;
            public int Row;

            public Section(int gridX, int gridY, int column = 1, int row = 1)
            {
                GridX = gridX;
                GridY = gridY;
                Column = column;
                Row = row;
            }
        }

        public static Dictionary<Item, List<Section>> Data { get; set; }

        public static void Main(string[] args)
        {
            InitializeData();

            using (var fout = new StreamWriter(GenerateHistoryPath()))
            {
                WriteHeader(fout);
                foreach (var item in Data)
                {
                    foreach (var section in item.Value)
                    {
                        WriteSection(fout, item.Key, section);
                    }
                }
                WriteFooter(fout);
            }
        }

        public static void InitializeData()
        {
            Data = new Dictionary<Item, List<Section>>
            {
                {new Item("FloorBlock"), new List<Section>
                {
                    new Section(0, 0, 10, 2)
                }},
            };
        }

        public static string GenerateHistoryPath()
        {
            var time = DateTime.Now;
            var timeString = string.Format("{0:D4}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}",
                time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
            return @"..\..\History\LevelData" + timeString + ".xml";
        }

        public static string GetOutputPath(string fileName)
        {
            return @"..\..\..\";
        }

        public static void WriteHeader(StreamWriter fout)
        {
            fout.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            fout.WriteLine("<XnaContent>");
            fout.WriteLine("  <Asset Type=\"LevelLoader.ObjectData[]\">");
        }

        public static void WriteFooter(StreamWriter fout)
        {
            fout.WriteLine("  </Asset>");
            fout.WriteLine("</XnaContent>");
        }

        public static void WriteSection(StreamWriter fout, Item item, Section section)
        {
            for (var column = 0; column < section.Column; column++)
                for (var row = 0; row < section.Row; row++)
                {
                    var locationX = (int) ((column + 0.5)*GameSettings.GridUnit*GameSettings.SpriteScale*item.GridWidth);
                    var locationY = (int) (Camera.Height - row*GameSettings.GridUnit*GameSettings.SpriteScale*item.GridHeight);
                    fout.WriteLine("    <Item>");
                    fout.WriteLine("      <Type>" + item.Type + "</Type>");
                    fout.WriteLine("      <Version>" + item.Version + "</Version>");
                    fout.WriteLine("      <Location>" + locationX + " " + locationY + "</Location>");
                    fout.WriteLine("    </Item>");
                }
        }
    }
}
