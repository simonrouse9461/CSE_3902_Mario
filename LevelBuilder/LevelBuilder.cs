using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using SuperMario;

namespace LevelBuilder
{
    public class LevelBuilder
    {
        private static int _id;

        private static int Id
        {
            get
            {
                _id++;
                return _id-1;
            }
        }

        public static string OutputFile { get; set; }

        public static Dictionary<Item, Section[]> Data { get; set; }

        public static void Main(string[] args)
        {
            GenerateLevel<OverWorldLevel>();
            GenerateLevel<SecretLevel>();
            GenerateLevel<UndergroundLevel>();
        }

        public static void GenerateLevel<T>() where T : LevelKernel, new()
        {
            InitializeData<T>();

            using (StreamWriter fout1 = new StreamWriter(GenerateHistoryPath()),
                fout2 = new StreamWriter(GetOutputPath(OutputFile)))
            {
                WriteHeader(fout1);
                WriteHeader(fout2);
                foreach (var item in Data)
                {
                    foreach (var section in item.Value)
                    {
                        WriteSection(fout1, item.Key, section);
                        WriteSection(fout2, item.Key, section);
                    }
                }
                WriteFooter(fout1);
                WriteFooter(fout2);
            }
        }

        public static void InitializeData<T>() where T : LevelKernel, new()
        {
            var level = new T();
            Data = level.ObjectData;
            OutputFile = level.OutputFile;
        }

        public static string GenerateUniqueId()
        {
            var time = DateTime.Now;
            return string.Format("{0:D4}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}{6:D2}",
                time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, Id);
        }

        public static string GenerateHistoryPath()
        {
            return @"..\..\History\LevelData" + GenerateUniqueId() + ".xml";
        }

        public static string GetOutputPath(string fileName)
        {
            return @"..\..\..\SuperMarioGame\SuperMarioGameContent\" + fileName + ".xml";
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
            for (var column = section.GridX; column < section.GridX + section.Column; column+=item.GridWidth)
                for (var row = section.GridY; row < section.GridY + section.Row; row += item.GridHeight)
                {
                    var locationX =
                        (int)
                            (((column + 0.5*item.GridWidth)*GameSettings.GridUnit + section.OffsetX)*
                             GameSettings.SpriteScale);
                    var locationY =
                        (int) (Camera.Height - (row*GameSettings.GridUnit + section.OffsetY)*GameSettings.SpriteScale);
                    fout.WriteLine("    <Item>");
                    fout.WriteLine("      <Type>" + item.Type + "</Type>");
                    fout.WriteLine("      <Version>" + item.Version + "</Version>");
                    fout.WriteLine("      <Location>" + locationX + " " + locationY + "</Location>");
                    fout.WriteLine("    </Item>");
                }
        }
    }
}
