using System.Collections.Generic;

namespace LevelGenerator
{
    public struct StairBuilder
    {
        public enum Shape
        {
            Upstairs,
            Downstairs
        }

        public Shape StairShape;
        public int CliffX;
        public int BaseY;
        public int Length;
        public int Height;

        public StairBuilder(Shape shape, int cliffX, int baseY, int length, int height = 0)
        {
            StairShape = shape;
            CliffX = cliffX;
            BaseY = baseY;
            Length = length;
            Height = height == 0 ? length : height;
        }

        public List<Section> GetSectionList()
        {
            var list = new List<Section>();
            for (var level = 0; level < Height; level++)
            {
                var gridY = BaseY + level;
                var gridX = StairShape == Shape.Downstairs ? CliffX : CliffX + level - Length + 1;
                var length = Length - level;
                list.Add(new Section(gridX, gridY, length));
            }
            return list;
        }
    }
}