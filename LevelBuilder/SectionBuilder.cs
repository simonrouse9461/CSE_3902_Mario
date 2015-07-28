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

        public static Section[] Level(int altitude, int offsetX, int offsetY, int[] xPositions, Dictionary<int, int> lines)
        {
            lines = lines ?? new Dictionary<int, int>();
            var singleList = (from x in xPositions
                select Section.Single(x, altitude, offsetX, offsetY)).ToList();
            var lineList = (from line in lines
                select Section.Line(line.Key, altitude, line.Value, offsetX, offsetY)).ToList();
            return singleList.Concat(lineList).ToArray();
        }

        public static Section[] Level(int altitude, int offsetX, int offsetY, int[] xPositions)
        {
            return Level(altitude, offsetX, offsetY, xPositions, new Dictionary<int, int>());
        }

        public static Section[] Level(int altitude, int offsetX, int offsetY, Dictionary<int, int> lines)
        {
            return Level(altitude, offsetX, offsetY, new int[0], lines);
        }

        public static Section[] Level(int altitude, int[] xPositions, Dictionary<int, int> lines = null)
        {
            return Level(altitude, 0, 0, xPositions, lines);
        }
    }
}