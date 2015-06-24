using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace WindowsGame1
{
    public class MarioNormalBlockCollisions
    {
        private MarioGame TestGame;
        private MarioObject TestMario { get; set; }
        private MarioObject CompareMario { get; set; }
        private NormalBlockObject TestNormalBlock { get; set; }

        private ICommand TestCommand;
        private ICommand CompareCommand;

        public void MarioNormalBlockRightCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject(world);
            CompareMario = new MarioObject(world);
            TestNormalBlock = new NormalBlockObject(world);
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that block is not broken
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioNormalBlockRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioNormalBlockRightCollision has Failed\r\n");
            }
        }
        public void MarioNormalBlockLeftCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject(world);
            CompareMario = new MarioObject(world);
            TestNormalBlock = new NormalBlockObject(world);
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that block is not broken
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioNormalBlockLeftCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioNormalBlockLeftCollision has Failed\r\n");
            }
        }

        public void MarioNormalBlockTopCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject(world);
            CompareMario = new MarioObject(world);
            TestNormalBlock = new NormalBlockObject(world);
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioDownCommand(TestGame);
            CompareCommand = new MarioDownCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that block is not broken
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioNormalBlockRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioNormalBlockRightCollision has Failed\r\n");
            }
        }
        public void MarioNormalBlockBottomCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject(world);
            CompareMario = new MarioObject(world);
            TestNormalBlock = new NormalBlockObject(world);
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioUpCommand(TestGame);
            CompareCommand = new MarioUpCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that block is broken
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioNormalBlockBottomCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioNormalBlockBottomCollision has Failed\r\n");
            }
        }
    }
}
