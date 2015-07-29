using System;

namespace LevelBuilder
{
    public class Item
    {
        public ItemCategory Category;
        public string Type;
        public string Version;
        public int GridWidth;
        public int GridHeight;

        public Item(ItemCategory category, string type, string version, int gridWidth, int gridHeight)
        {
            Category = category;
            Type = type;
            Version = version;
            GridWidth = gridWidth;
            GridHeight = gridHeight;
        }

        public Item(string type, string version, int gridWidth = 1, int gridHeight = 1)
            : this(ItemCategory.Body, type, version, gridWidth, gridHeight) { }

        public Item(string type, int gridWidth = 1, int gridHeight = 1)
            : this(type, string.Empty, gridWidth, gridHeight) { }

        public static Item TopCap(string type, string version, int gridWidth = 1, int gridHeight = 1)
        {
            return new Item(ItemCategory.TopCap, type, version, gridWidth, gridHeight);
        }

        public static Item BottomCap(string type, string version, int gridWidth = 1, int gridHeight = 1)
        {
            return new Item(ItemCategory.BottomCap, type, version, gridWidth, gridHeight);
        }

        public static Item LeftCap(string type, string version, int gridWidth = 1, int gridHeight = 1)
        {
            return new Item(ItemCategory.LeftCap, type, version, gridWidth, gridHeight);
        }

        public static Item RightCap(string type, string version, int gridWidth = 1, int gridHeight = 1)
        {
            return new Item(ItemCategory.RightCap, type, version, gridWidth, gridHeight);
        }

        public static Item TopCap(string type, int gridWidth = 1, int gridHeight = 1)
        {
            return TopCap(type, string.Empty, gridWidth, gridHeight);
        }

        public static Item BottomCap(string type, int gridWidth = 1, int gridHeight = 1)
        {
            return BottomCap(type, string.Empty, gridWidth, gridHeight);
        }

        public static Item LeftCap(string type, int gridWidth = 1, int gridHeight = 1)
        {
            return LeftCap(type, string.Empty, gridWidth, gridHeight);
        }

        public static Item RightCap(string type, int gridWidth = 1, int gridHeight = 1)
        {
            return RightCap(type, string.Empty, gridWidth, gridHeight);
        }

        public Item Clone
        {
            get { return new Item(Type, Version, GridWidth, GridHeight); }
        }

        public Item SwitchVersion(string version)
        {
            return new Item(Type, version, GridWidth, GridHeight);
        }
    }
}