namespace LevelBuilder
{
    public struct Section
    {
        public int GridX;
        public int GridY;
        public int Column;
        public int Row;

        public Section(int gridX, int gridY, int column = 1, int row = 1)
        {
            GridX = gridX;
            GridY = gridY;
            Column = column;
            Row = row;
        }
    }
}