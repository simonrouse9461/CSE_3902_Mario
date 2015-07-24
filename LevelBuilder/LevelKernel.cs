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

        protected void AddObjectBatch(Item item, int gridX, int gridY, int length = 1)
        {
            ObjectData.Add(item, new[] {Section.Line(gridX, gridY, length)});
        }

        protected void AddObjectBatch(Item item, Section[] sectionList)
        {
            ObjectData.Add(item, sectionList);
        }

        protected void AddObjectBatch(Item item, StairBuilder[] stairList = null)
        {
            var stairs = (from stair in stairList
                from section in stair.GetSectionArray()
                select section).ToArray();
            AddObjectBatch(item, stairs);
        }

        protected void SetOutputFile(string file)
        {
            OutputFile = file;
        }
    }
}