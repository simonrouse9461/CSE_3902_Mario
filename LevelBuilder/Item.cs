namespace LevelBuilder
{
    public class Item
    {
        public string Type;
        public string Version;
        public int GridWidth;
        public int GridHeight;

        public Item(string type, string version, int gridWidth = 1, int gridHeight = 1)
        {
            Type = type;
            Version = version;
            GridWidth = gridWidth;
            GridHeight = gridHeight;
        }

        public Item(string type, int gridWidth = 1, int gridHeight = 1)
        {
            Type = type;
            Version = string.Empty;
            GridWidth = gridWidth;
            GridHeight = gridHeight;
        }
    }
}