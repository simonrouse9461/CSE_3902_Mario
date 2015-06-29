using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace WindowsGame1
{
    public class MarioDestructibleBlockCollisions
    {
        private MarioGame TestGame;
        private MarioObject TestMario { get; set; }
        private MarioObject CompareMario { get; set; }
        private DestructibleBlockObject TestDestructibleBlock { get; set; }

        private ICommand TestCommand;
        private ICommand CompareCommand;
        public void MarioDestructibleBlockRightCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestDestructibleBlock = new DestructibleBlockObject();
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that block is not used
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioDestructibleBlockRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioDestructibleBlockRightCollision has Failed\r\n");
            }
        }
        public void MarioDestructibleBlockLeftCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestDestructibleBlock = new DestructibleBlockObject();
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that block is not used
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioDestructibleBlockLeftCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioDestructibleBlockLeftCollision has Failed\r\n");
            }
        }

        public void MarioDestructibleBlockTopCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestDestructibleBlock = new DestructibleBlockObject();
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioDownCommand(TestGame);
            CompareCommand = new MarioDownCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that block is not used
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioDestructibleBlockRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioDestructibleBlockRightCollision has Failed\r\n");
            }
        }
        public void MarioDestructibleBlockBottomCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestDestructibleBlock = new DestructibleBlockObject();
            CompareCommand = new MarioBigCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioUpCommand(TestGame);
            CompareCommand = new MarioUpCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that block is used
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioDestructibleBlockBottomCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioDestructibleBlockBottomCollision has Failed\r\n");
            }
        }
    }
}
