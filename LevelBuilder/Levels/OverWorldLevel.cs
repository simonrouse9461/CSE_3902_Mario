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
                Section.Single(16, 5),
                Section.Single(23, 5),
                Section.Single(106, 5),
                Section.Single(109, 5),
                Section.Single(112, 5),
                Section.Single(170, 5),
                Section.Single(22, 9),
                Section.Single(94, 9),
                Section.Line(129, 9, 2)
            });
            AddObjectBatch(new Item("QuestionBlockObject", "ItemQuestionBlock"), new[]
            {
                Section.Single(21, 5),
                Section.Single(78, 5),
                Section.Single(109, 9),
            });
            AddObjectBatch(new Item("NormalBlockObject"), new[]
            {
                Section.Single(20, 5),
                Section.Single(22, 5),
                Section.Single(24, 5),
                Section.Single(77, 5),
                Section.Single(79, 5),
                Section.Single(100, 5),
                Section.Single(118, 5),
                Section.Single(129, 5),
                Section.Single(130, 5),
                Section.Line(168, 5, 2),
                Section.Single(171, 5),
                Section.Line(80, 9, 8),
                Section.Line(91, 9, 3),
                Section.Line(121, 9, 3),
                Section.Single(128, 9),
                Section.Single(131, 9)
            });
            AddObjectBatch(new Item("NormalBlockObject", "CoinNormalBlock"), 94, 5);
            AddObjectBatch(new Item("NormalBlockObject", "StarNormalBlock"), 101, 5);
            AddObjectBatch(new Item("HiddenBlockObject", "ExtraLifeHiddenBlock"), 64, 6);
            AddObjectBatch(new Item("BlockKernel"), 198, 2);
            AddObjectBatch(new Item("BlockKernel"), new[]
            {
                new StairBuilder(StairBuilder.Shape.Upstairs, 137, 2, 4),
                new StairBuilder(StairBuilder.Shape.Downstairs, 140, 2, 4),
                new StairBuilder(StairBuilder.Shape.Upstairs, 152, 2, 5, 4),
                new StairBuilder(StairBuilder.Shape.Downstairs, 155, 2, 4),
                new StairBuilder(StairBuilder.Shape.Upstairs, 189, 2, 9, 8),
            });
            AddObjectBatch(new Item("FlagPoleObject"), 198, 3);
            AddObjectBatch(new Item("CastleObject", 5), 202, 2);
        }
    }
}