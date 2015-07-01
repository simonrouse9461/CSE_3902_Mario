using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace WindowsGame1
{
    public class MarioMushroomCollisions
    {
        private MarioGame TestGame;
        private MarioObject TestMario { get; set; }
        private MarioObject CompareMario { get; set; }
        private Mushroom TestMushroom { get; set; }

        private ICommand TestCommand;
        private ICommand CompareCommand;

        public void MarioMushroomRightCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestMushroom = new Mushroom();
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is now big Mario
            if (TestState == CompareState)
            {
                Console.Write("MarioMushroomRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioMushroomRightCollision has Failed\r\n");
            }
        }

        public void MarioMushroomLeftCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestMushroom = new Mushroom();
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioLeftCommand(TestGame);
            CompareCommand = new MarioLeftCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is now big Mario
            if (TestState == CompareState)
            {
                Console.Write("MarioMushroomLeftCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioMushroomLeftCollision has Failed\r\n");
            }
        }

        public void MarioMushroomTopCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestMushroom = new Mushroom();
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioUpCommand(TestGame);
            CompareCommand = new MarioUpCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is now big Mario
            if (TestState == CompareState)
            {
                Console.Write("MarioMushroomTopCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioMushroomTopCollision has Failed\r\n");
            }
        }
        public void MarioMushroomBottomCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestMushroom = new Mushroom();
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioDownCommand(TestGame);
            CompareCommand = new MarioDownCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is now big Mario
            if (TestState == CompareState)
            {
                Console.Write("MarioMushroomBottomCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioMushroomBottomCollision has Failed\r\n");
            }
        }
        public void FireMarioMushroomBottomCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestMushroom = new Mushroom();
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioDownCommand(TestGame);
            CompareCommand = new MarioDownCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is now Fire Mario
            if (TestState == CompareState)
            {
                Console.Write("FireMarioMushroomBottomCollision has Passed\r\n");
            }
            else
            {
                Console.Write("FireMarioMushroomBottomCollision has Failed\r\n");
            }
        }
    }
}
