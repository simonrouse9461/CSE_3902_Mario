using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace WindowsGame1
{

    public class MarioGoombaCollisions
    {
        private MarioGame TestGame;
        private MarioObject TestMario { get; set; }
        private MarioObject CompareMario { get; set; }
        private Goomba TestGoomba { get; set; }

        private ICommand TestCommand;
        private ICommand CompareCommand;

        public void MarioGoombaRightCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestGoomba = new Goomba();
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is now dead
            if (TestState == CompareState)
            {
                Console.Write("MarioGoombaRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioGoombaRightCollision has Failed\r\n");
            }
        }

        public void MarioGoombaLeftCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestGoomba = new Goomba();
            TestCommand = new MarioLeftCommand(TestGame);
            CompareCommand = new MarioLeftCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is now dead
            if (TestState == CompareState)
            {
                Console.Write("MarioGoombaLeftCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioGoombaLeftCollision has Failed\r\n");
            }
        }

        public void MarioGoombaTopCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestGoomba = new Goomba();
            TestCommand = new MarioUpCommand(TestGame);
            CompareCommand = new MarioUpCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is not dead
            if (TestState == CompareState)
            {
                Console.Write("MarioGoombaTopCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioGoombaTopCollision has Failed\r\n");
            }
        }
        public void MarioGoombaBottomCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestGoomba = new Goomba();
            TestCommand = new MarioDownCommand(TestGame);
            CompareCommand = new MarioDownCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.CoreGetter;
            var CompareState = CompareMario.CoreGetter;

            //Check that Mario is now dead
            if (TestState == CompareState)
            {
                Console.Write("MarioGoombaBottomCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioGoombaBottomCollision has Failed\r\n");
            }
        }
    }
}
