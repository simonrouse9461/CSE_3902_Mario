using System;
using System.Collections.Generic;
using System.Linq;

namespace LevelBuilder
{
    public abstract class LevelKernel
    {
        public string OutputFile { get; private set; }
        public Dictionary<Item, Section[]> ObjectData { get; private set; }

        protected LevelKernel()
        {
            ObjectData = new Dictionary<Item, Section[]>();
        }

        protected void BatchAdd(Item item, int gridX, int gridY, int length = 1)
        {
            ObjectData.Add(item, new[] {Section.Line(gridX, gridY, length)});
        }

        protected void BatchAdd(Item item, Section[] sectionList)
        {
            ObjectData.Add(item, sectionList);
        }

        protected void BatchAdd(Item item, Section[][] sectionBuilderList)
        {
            foreach (var sectionList in sectionBuilderList)
            {
                BatchAdd(item.Clone, sectionList);
            }
        }

        protected void SetOutputFile(string file)
        {
            OutputFile = file;
        }
    }
}