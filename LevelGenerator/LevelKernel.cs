using System.Collections.Generic;

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

        protected void AddObjectBatch(Item item, Section[] sectionList)
        {
            ObjectData.Add(item, sectionList);
        }

        protected void SetOutputFile(string file)
        {
            OutputFile = file;
        }
    }
}