namespace LevelBuilder
{
    public struct Section
    {
        public int GridX;
        public int GridY;
        public int Column;
        public int Row;
        public int OffsetX;
        public int OffsetY;

        public Section(int gridX, int gridY, int column, int row, int offsetX = 0, int offsetY = 0)
        {
            GridX = gridX;
            GridY = gridY;
            Column = column;
            Row = row;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }

        public static Section Single(int gridX, int gridY, int offsetX = 0, int offsetY = 0)
        {
            return new Section(gridX, gridY, 1, 1, offsetX, offsetY);
        }

        public static Section Line(int gridX, int gridY, int column, int offsetX = 0, int offsetY = 0)
        {
            return new Section(gridX, gridY, column, 1, offsetX, offsetY);
        }
    }
}