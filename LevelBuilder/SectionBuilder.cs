using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LevelBuilder
{
    public static class SectionBuilder
    {
        public enum StairShape
        {
            Upstairs,
            Downstairs
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

        public static Section[] Level(int altitude, int[] xPositions, Dictionary<int, int> lines = null)
        {
            lines = lines ?? new Dictionary<int, int>();
            var singleList = (from x in xPositions
                select Section.Single(x, altitude)).ToList();
            var lineList = (from line in lines
                select Section.Line(line.Key, altitude, line.Value)).ToList();
            return singleList.Concat(lineList).ToArray();
        }
    }
}