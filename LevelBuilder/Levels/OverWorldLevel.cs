using System.Collections.Generic;
using System.Linq;

namespace LevelBuilder
{
    public class OverWorldLevel : LevelKernel
    {
        public OverWorldLevel()
        {
            SetOutputFile("LevelData");
            BatchAdd(new Item("FloorBlockObject"), new[]
            {
                Section.Range(0, 68, 0, 1),
                Section.Matrix(71, 0, 15, 2),
                Section.Range(89, 152, 0, 1),
                Section.Range(155, 211, 0, 1)
            });
            BatchAdd(new Item("PipeBody", 2),
                Item.TopCap("PipeHead", 2),
                new[]
                {
                    Section.Single(28, 2),
                    Section.Single(163, 2),
                    Section.Single(179, 2),
                    Section.Tower(38, 2, 2),
                    Section.Tower(46, 2, 3),
                    Section.Tower(57, 2, 3)
                });
            BatchAdd(new Item("QuestionBlockObject", "CoinQuestionBlock"), new[]
            {
                SectionBuilder.Level(5,
                    new[] {16, 23, 106, 109, 112, 170}),
                SectionBuilder.Level(9,
                    new[] {22, 94},
                    new Dictionary<int, int> {{129, 2}})
            });
            BatchAdd(new Item("QuestionBlockObject", "ItemQuestionBlock"), new[]
            {
                Section.Single(21, 5),
                Section.Single(78, 5),
                Section.Single(109, 9)
            });
            BatchAdd(new Item("NormalBlockObject"), new[]
            {
                SectionBuilder.Level(5,
                    new[] {20, 22, 24, 77, 79, 100, 118, 129, 130, 171},
                    new Dictionary<int, int> {{168, 2}}),
                SectionBuilder.Level(9,
                    new[] {128, 131},
                    new Dictionary<int, int> {{80, 8}, {91, 3}, {121, 3}})
            });
            BatchAdd(new Item("NormalBlockObject", "CoinNormalBlock"), 94, 5);
            BatchAdd(new Item("NormalBlockObject", "StarNormalBlock"), 101, 5);
            BatchAdd(new Item("HiddenBlockObject", "ExtraLifeHiddenBlock"), 64, 6);
            BatchAdd(new Item("BlockKernel"), new[]
            {
                Section.Single(198, 2).ToList,
                SectionBuilder.Stair(SectionBuilder.StairShape.Upstairs, 137, 2, 4),
                SectionBuilder.Stair(SectionBuilder.StairShape.Downstairs, 140, 2, 4),
                SectionBuilder.Stair(SectionBuilder.StairShape.Upstairs, 152, 2, 5, 4),
                SectionBuilder.Stair(SectionBuilder.StairShape.Downstairs, 155, 2, 4),
                SectionBuilder.Stair(SectionBuilder.StairShape.Upstairs, 189, 2, 9, 8)
            });
            BatchAdd(new Item("FlagPole"), Section.Tower(198, 3, 9).ToList);
            BatchAdd(new Item("Flag"), Section.Single(198, 11, -8).ToList);
            BatchAdd(new Item("Knob"), 198, 12);
            BatchAdd(new Item("CastleObject", 5), 202, 2);
            BatchAdd(new Item("Goomba"), new[]
            {
                Section.Single(21, 2, -6),
                Section.Single(40, 2, 3),
                Section.Single(53, 2, -6),
                Section.Single(54, 2, 2),
                Section.Single(95, 2, -4),
                Section.Single(96, 2, 4),
                Section.Single(124, 2, -10),
                Section.Single(125, 2, -2),
                Section.Single(127, 2, -2),
                Section.Single(128, 2, 6),
                Section.Single(173, 2, 2),
                Section.Single(174, 2, 10),
                Section.Single(79, 7, -4, 8),
                Section.Single(82, 10, -6),
            });
            BatchAdd(new Item("Koopa"), new[] {Section.Single(106, 2, -6)});
            BatchAdd(new Item("Cloud", "Body"),
                Item.LeftCap("Cloud", "Head"),
                Item.RightCap("Cloud", "Tail"),
                new[]
                {
                    SectionBuilder.Level(10, 0, 8,
                        new[] {9, 57, 105, 153, 201},
                        new Dictionary<int, int> {{28, 3}, {76, 3}, {124, 3}, {172, 3}}),
                    SectionBuilder.Level(11, 0, 8,
                        new[] {20, 68, 116, 164},
                        new Dictionary<int, int> {{37, 2}, {85, 2}, {133, 2}, {181, 2}}),
                });
            BatchAdd(new Item("Bush", "Body"),
                Item.LeftCap("Bush", "Head"),
                Item.RightCap("Bush", "Tail"),
                SectionBuilder.Level(2,
                    new[] {24, 72, 120, 168},
                    new Dictionary<int, int>
                    {
                        {12, 3},
                        {60, 3},
                        {108, 3},
                        {156, 3},
                        {204, 3},
                        {42, 2},
                        {90, 2},
                        {138, 2},
                        {186, 2}
                    }));
            BatchAdd(new Item("Hill", "Large", 5, 2), SectionBuilder.Level(2, new[] {0, 48, 96, 144, 192}));
            BatchAdd(new Item("Hill", "Small", 3), SectionBuilder.Level(2, new[] {16, 64, 112, 160, 208}));
        }
    }
}