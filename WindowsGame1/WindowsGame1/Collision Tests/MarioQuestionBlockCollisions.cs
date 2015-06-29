using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace WindowsGame1
{
    public class MarioQuestionBlockCollisions
    {
        private MarioGame TestGame;
        private MarioObject TestMario { get; set; }
        private MarioObject CompareMario { get; set; }
        private QuestionBlockObject TestQuestionBlock { get; set; }

        private ICommand TestCommand;
        private ICommand CompareCommand;
        public void MarioQuestionBlockRightCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestQuestionBlock = new QuestionBlockObject();
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that block is not used
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioQuestionBlockRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioQuestionBlockRightCollision has Failed\r\n");
            }
        }
        public void MarioQuestionBlockLeftCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestQuestionBlock = new QuestionBlockObject();
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that block is not used
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioQuestionBlockLeftCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioQuestionBlockLeftCollision has Failed\r\n");
            }
        }

        public void MarioQuestionBlockTopCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestQuestionBlock = new QuestionBlockObject();
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioDownCommand(TestGame);
            CompareCommand = new MarioDownCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that block is not used
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioQuestionBlockRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioQuestionBlockRightCollision has Failed\r\n");
            }
        }
        public void MarioQuestionBlockBottomCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestQuestionBlock = new QuestionBlockObject();
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioUpCommand(TestGame);
            CompareCommand = new MarioUpCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that block is used
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioQuestionBlockBottomCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioQuestionBlockBottomCollision has Failed\r\n");
            }
        }
    }
}
