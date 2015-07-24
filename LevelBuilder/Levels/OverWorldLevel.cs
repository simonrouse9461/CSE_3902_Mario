using System.Collections.Generic;
using System.Linq;

namespace LevelBuilder
{
    public class OverWorldLevel : LevelKernel
    {
        public OverWorldLevel()
        {
            SetOutputFile("LevelData");
            AddObjectBatch(new Item("FloorBlockObject"), new[]
            {
                new Section(0, 0, 69, 2),
                new Section(71, 0, 15, 2),
                new Section(89, 0, 64, 2),
                new Section(155, 0, 57, 2)
            });
            AddObjectBatch(new Item("SmallPipeObject", 2, 2), new[]
            {
                Section.Single(28, 2),
                Section.Single(163, 2),
                Section.Single(179, 2)
            });
            AddObjectBatch(new Item("MediumPipeObject", 2, 3), 38, 2);
            AddObjectBatch(new Item("GreenPipeObject", 2, 4), new[]
            {
                Section.Single(46, 2),
                Section.Single(57, 2),
            });
            AddObjectBatch(new Item("QuestionBlockObject", "CoinQuestionBlock"), new[]
            {
                SectionBuilder.Level(5,
                    new[] {16, 23, 106, 109, 112, 170}),
                SectionBuilder.Level(9,
                    new[] {22, 94},
                    new Dictionary<int, int> {{129, 2}})
            });
            AddObjectBatch(new Item("QuestionBlockObject", "ItemQuestionBlock"), new[]
            {
                Section.Single(21, 5),
                Section.Single(78, 5),
                Section.Single(109, 9)
            });
            AddObjectBatch(new Item("NormalBlockObject"), new[]
            {
                SectionBuilder.Level(5,
                    new[] {20, 22, 24, 77, 79, 100, 118, 129, 130, 171},
                    new Dictionary<int, int> {{168, 2}}),
                SectionBuilder.Level(9,
                    new[] {128, 131},
                    new Dictionary<int, int> {{80, 8}, {91, 3}, {121, 3}})
            });
            AddObjectBatch(new Item("NormalBlockObject", "CoinNormalBlock"), 94, 5);
            AddObjectBatch(new Item("NormalBlockObject", "StarNormalBlock"), 101, 5);
            AddObjectBatch(new Item("HiddenBlockObject", "ExtraLifeHiddenBlock"), 64, 6);
            AddObjectBatch(new Item("BlockKernel"), 198, 2);
            AddObjectBatch(new Item("BlockKernel"), new[]
            {
                SectionBuilder.Stair(SectionBuilder.StairShape.Upstairs, 137, 2, 4),
                SectionBuilder.Stair(SectionBuilder.StairShape.Downstairs, 140, 2, 4),
                SectionBuilder.Stair(SectionBuilder.StairShape.Upstairs, 152, 2, 5, 4),
                SectionBuilder.Stair(SectionBuilder.StairShape.Downstairs, 155, 2, 4),
                SectionBuilder.Stair(SectionBuilder.StairShape.Upstairs, 189, 2, 9, 8)
            });
            AddObjectBatch(new Item("FlagPoleObject"), 198, 3);
            AddObjectBatch(new Item("CastleObject", 5), 202, 2);
        }
    }
}