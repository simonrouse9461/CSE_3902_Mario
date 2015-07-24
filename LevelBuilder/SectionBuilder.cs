using System.Collections.Generic;

namespace LevelBuilder
{
    public class SectionBuilder
    {
        public enum StairShape
        {
            Upstairs,
            Downstairs
        }

        private SectionBuilder()
        {
        }

        public static Section[] Stair(StairShape shape, int cliffX, int baseY, int length, int? height = null)
        {
            height = height ?? length;
            var list = new List<Section>();
            for (var level = 0; level < height; level++)
            {
                var gridY = baseY + level;
                var gridX = shape == StairShape.Downstairs ? cliffX : cliffX + level - length + 1;
                var l = length - level;
                list.Add(Section.Line(gridX, gridY, l));
            }
            return list.ToArray();
        }
    }
}