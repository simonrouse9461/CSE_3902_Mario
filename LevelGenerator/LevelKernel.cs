using System.Collections.Generic;

namespace LevelGenerator
{
    public abstract class LevelKernel
    {
        public Dictionary<Item, Section[]> ObjectData { get; set; }

        protected LevelKernel()
        {
            ObjectData = new Dictionary<Item, Section[]>();
        }

        protected void AddObjectBatch(Item item, Section[] sectionList)
        {
            ObjectData.Add(item, sectionList);
        } 
    }
}