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

        private Section(int gridX, int gridY, int column, int row, int offsetX, int offsetY)
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

        public static Section Matrix(int gridX, int gridY, int column, int row, int offsetX = 0, int offsetY = 0)
        {
            return new Section(gridX, gridY, column, row, offsetX, offsetY);
        }

        public static Section Range(int startX, int endX, int startY, int endY, int offsetX = 0, int offsetY = 0)
        {
            return new Section(startX, startY, endX - startX + 1, endY - startY + 1, offsetX, offsetY);
        }
    }
}