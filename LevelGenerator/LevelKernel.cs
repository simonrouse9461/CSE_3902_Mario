using System.Collections.Generic;
using System.Linq;

namespace LevelGenerator
{
    public abstract class LevelKernel
    {
        public string OutputFile { get; private set; }
        public Dictionary<Item, Section[]> ObjectData { get; private set; }

        protected LevelKernel()
        {
            ObjectData = new Dictionary<Item, Section[]>();
        }

        protected void AddObjectBatch(Item item, Section[] sectionList, StairBuilder[] stairList = null)
        {
            if (stairList == null)
            {
                ObjectData.Add(item, sectionList);
                return;
            }
            var stairs = (from stair in stairList
                from section in stair.GetSectionList()
                select section).ToArray();
            var mergedList = new Section[sectionList.Length + stairs.Length];
            sectionList.CopyTo(mergedList, 0);
            stairs.CopyTo(mergedList, sectionList.Length);
            ObjectData.Add(item, mergedList);
        }

        protected void SetOutputFile(string file)
        {
            OutputFile = file;
        }
    }
}