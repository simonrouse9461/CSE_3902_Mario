namespace LevelBuilder
{
    public class Item
    {
        public string Type;
        public string Version;
        public int GridWidth;
        public int GridHeight;

        public Item(string type, string version = null, int gridWidth = 1, int gridHeight = 1)
        {
            Type = type;
            Version = version ?? string.Empty;
            GridWidth = gridWidth;
            GridHeight = gridHeight;
        }
    }
}