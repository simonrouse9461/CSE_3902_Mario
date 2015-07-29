using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        protected void BatchAdd(Item item1, Item item2, Item item3, Item item4, Item item5, Section[] sectionList)
        {
            var itemList = new[] {item1, item2, item3, item4, item5};
            var itemDictionary = new Dictionary<ItemCategory, Item>();
            foreach (var item in itemList)
            {
                if (item != null) itemDictionary.Add(item.Category, item);
            }
            var topList = new List<Section>();
            var bottomList = new List<Section>();
            var leftList = new List<Section>();
            var rightList = new List<Section>();
            foreach (var section in sectionList)
            {
                topList.Add(Section.Line(section.GridX, section.GridY + section.Row, section.Column, section.OffsetX,
                    section.OffsetY));
                bottomList.Add(Section.Line(section.GridX, section.GridY - 1, section.Column, section.OffsetX,
                    section.OffsetY));
                leftList.Add(Section.Tower(section.GridX - 1, section.GridY, section.Row, section.OffsetX,
                    section.OffsetY));
                rightList.Add(Section.Line(section.GridX + section.Column, section.GridY, section.Row, section.OffsetX,
                    section.OffsetY));
            }
            ObjectData.Add(itemDictionary[ItemCategory.Body].Clone, sectionList);
            if (itemDictionary.ContainsKey(ItemCategory.TopCap))
                ObjectData.Add(itemDictionary[ItemCategory.TopCap].Clone, topList.ToArray());
            if (itemDictionary.ContainsKey(ItemCategory.BottomCap))
                ObjectData.Add(itemDictionary[ItemCategory.BottomCap].Clone, bottomList.ToArray());
            if (itemDictionary.ContainsKey(ItemCategory.LeftCap))
                ObjectData.Add(itemDictionary[ItemCategory.LeftCap].Clone, leftList.ToArray());
            if (itemDictionary.ContainsKey(ItemCategory.RightCap))
                ObjectData.Add(itemDictionary[ItemCategory.RightCap].Clone, rightList.ToArray());
        }

        protected void BatchAdd(Item item1, Item item2, Item item3, Item item4, Section[] sectionList)
        {
            BatchAdd(item1, item2, item3, item4, null, sectionList);
        }

        protected void BatchAdd(Item item1, Item item2, Item item3, Section[] sectionList)
        {
            BatchAdd(item1, item2, item3, null, null, sectionList);
        }

        protected void BatchAdd(Item item1, Item item2, Section[] sectionList)
        {
            BatchAdd(item1, item2, null, null, null, sectionList);
        }

        protected void BatchAdd(Item item1, Item item2, Item item3, Item item4, Item item5,
            Section[][] sectionBuilderList)
        {
            foreach (var sectionBuilder in sectionBuilderList)
            {
                BatchAdd(item1, item2, item3, item4, item5, sectionBuilder);
            }
        }

        protected void BatchAdd(Item item1, Item item2, Item item3, Item item4,
            Section[][] sectionBuilderList)
        {
            BatchAdd(item1, item2, item3, item4, null, sectionBuilderList);
        }

        protected void BatchAdd(Item item1, Item item2, Item item3,
            Section[][] sectionBuilderList)
        {
            BatchAdd(item1, item2, item3, null, null, sectionBuilderList);
        }

        protected void BatchAdd(Item item1, Item item2,
            Section[][] sectionBuilderList)
        {
            BatchAdd(item1, item2, null, null, null, sectionBuilderList);
        }

        protected void SetOutputFile(string file)
        {
            OutputFile = file;
        }
    }
}