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

        protected void BatchAdd(Item item, string headVersion, string tailVersion, Section[] sectionList)
        {
            var headList = new List<Section>();
            var tailList = new List<Section>();
            foreach (var section in sectionList)
            {
                headList.Add(Section.Single(section.GridX - 1, section.GridY, section.OffsetX, section.OffsetY));
                tailList.Add(Section.Single(section.GridX + section.Column, section.GridY, section.OffsetX,
                    section.OffsetY));
            }
            ObjectData.Add(item.Clone, sectionList);
            ObjectData.Add(item.SwitchVersion(headVersion), headList.ToArray());
            ObjectData.Add(item.SwitchVersion(tailVersion), tailList.ToArray());
        }

        protected void BatchAdd(Item item, string headVersion, string tailVersion, Section[][] sectionBuilderList)
        {
            foreach (var sectionBuilder in sectionBuilderList)
            {
                BatchAdd(item, headVersion, tailVersion, sectionBuilder);
            }
        }

        protected void SetOutputFile(string file)
        {
            OutputFile = file;
        }
    }
}