namespace LevelGenerator
{
    public class OverWorldLevel : LevelKernel
    {
        public OverWorldLevel()
        {
            SetOutputFile("LevelData");
            AddObjectBatch(new Item("FloorBlockObject"), new []
            {
                new Section(0, 0, 69, 2),
                new Section(71, 0, 15, 2),
                new Section(89, 0, 64, 2),
                new Section(155, 0, 57, 2)
            });
            AddObjectBatch(new Item("SmallPipeObject", null, 2, 2), new []
            {
                new Section(28, 2),
                new Section(163, 2),
                new Section(179, 2)
            });
            AddObjectBatch(new Item("MediumPipeObject", null, 2, 3), new[]
            {
                new Section(38, 2)
            });
            AddObjectBatch(new Item("GreenPipeObject", null, 2, 4), new[]
            {
                new Section(46, 2),
                new Section(57, 2),
            });
            AddObjectBatch(new Item("QuestionBlockObject", "CoinQuestionBlock"), new[]
            {
                new Section(16, 5),
                new Section(23, 5),
                new Section(106, 5),
                new Section(109, 5),
                new Section(112, 5),
                new Section(170, 5),
                new Section(22, 9),
                new Section(94, 9),
                new Section(129, 9, 2)
            });
            AddObjectBatch(new Item("QuestionBlockObject", "ItemQuestionBlock"), new[]
            {
                new Section(21, 5),
                new Section(78, 5),
                new Section(109, 9)
            });
            AddObjectBatch(new Item("NormalBlockObject"), new[]
            {
                new Section(20, 5),
                new Section(22, 5),
                new Section(24, 5),
                new Section(77, 5),
                new Section(79, 5),
                new Section(100, 5),
                new Section(118, 5),
                new Section(129, 5),
                new Section(130, 5),
                new Section(168, 5, 2),
                new Section(171, 5),
                new Section(80, 9, 8),
                new Section(91, 9, 3),
                new Section(121, 9, 3),
                new Section(128, 9),
                new Section(131, 9)
            });
            AddObjectBatch(new Item("NormalBlockObject", "CoinNormalBlock"), new[]
            {
                new Section(94, 5)
            });
            AddObjectBatch(new Item("NormalBlockObject", "StarNormalBlock"), new[]
            {
                new Section(101, 5)
            });
            AddObjectBatch(new Item("HiddenBlockObject", "ExtraLifeHiddenBlock"), new[]
            {
                new Section(64, 6)
            });
            AddObjectBatch(new Item("BlockKernel"),
                new[]
                {
                    new Section(198, 2)
                },
                new[]
                {
                    new StairBuilder(StairBuilder.Shape.Upstairs, 137, 2, 4),
                    new StairBuilder(StairBuilder.Shape.Downstairs, 140, 2, 4),
                    new StairBuilder(StairBuilder.Shape.Upstairs, 152, 2, 5, 4),
                    new StairBuilder(StairBuilder.Shape.Downstairs, 155, 2, 4),
                    new StairBuilder(StairBuilder.Shape.Upstairs, 189, 2, 9, 8),
                });
            AddObjectBatch(new Item("FlagPoleObject"), new[]
            {
                new Section(198, 3)
            });
            AddObjectBatch(new Item("CastleObject", null, 5), new[]
            {
                new Section(202, 2)
            });
        }
    }
}