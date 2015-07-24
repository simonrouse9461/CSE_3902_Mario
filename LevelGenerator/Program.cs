using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario;

namespace LevelGenerator
{
    class Program
    {
        public const string OutFile = "";
        public const int GridUnit = 16;

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

            WriteHeader();

            foreach (var item in Data)
            {
                foreach (var section in item.Value)
                {
                    WriteSection(item.Key, section);
                }
            }

            WriteFooter();
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

        public static void WriteHeader()
        {
            Console.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            Console.WriteLine("<XnaContent>");
            Console.WriteLine("  <Asset Type=\"LevelLoader.ObjectData[]\">");
        }

        public static void WriteFooter()
        {
            Console.WriteLine("  </Asset>");
            Console.WriteLine("</XnaContent>");
        }

        public static void WriteSection(Item item, Section section)
        {
            for (var column = 0; column < section.Column; column++)
                for (var row = 0; row < section.Row; row++)
                {
                    var locationX = (int) ((column + 0.5)*GridUnit*GameSettings.SpriteScale*item.GridWidth);
                    var locationY = (int) (Camera.Height - row*GridUnit*GameSettings.SpriteScale*item.GridHeight);
                    Console.WriteLine("    <Item>");
                    Console.WriteLine("      <Type>" + item.Type + "</Type>");
                    Console.WriteLine("      <Version>" + item.Version + "</Version>");
                    Console.WriteLine("      <Location>" + locationX + " " + locationY + "</Location>");
                    Console.WriteLine("    </Item>");
                }
        }
    }
}
