using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace WindowsGame1
{
    public class MarioKoopaCollisions
    {
        private MarioGame TestGame;
        private MarioObject TestMario { get; set; }
        private MarioObject CompareMario { get; set; }
        private Koopa TestKoopa { get; set; }

        private ICommand TestCommand;
        private ICommand CompareCommand;


        public void MarioKoopaRightCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestKoopa = new Koopa();
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is now dead
            if (TestState == CompareState)
            {
                Console.Write("MarioKoopaRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioKoopaRightCollision has Failed\r\n");
            }
        }

        public void MarioKoopaLeftCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestKoopa = new Koopa();
            TestCommand = new MarioLeftCommand(TestGame);
            CompareCommand = new MarioLeftCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is now dead
            if (TestState == CompareState)
            {
                Console.Write("MarioKoopaLeftCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioKoopaLeftCollision has Failed\r\n");
            }
        }

        public void MarioKoopaTopCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestKoopa = new Koopa();
            TestCommand = new MarioUpCommand(TestGame);
            CompareCommand = new MarioUpCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is not dead
            if (TestState == CompareState)
            {
                Console.Write("MarioKoopaTopCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioKoopaTopCollision has Failed\r\n");
            }
        }
        public void MarioKoopaBottomCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestKoopa = new Koopa();
            TestCommand = new MarioDownCommand(TestGame);
            CompareCommand = new MarioDownCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is now dead
            if (TestState == CompareState)
            {
                Console.Write("MarioKoopaBottomCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioKoopaBottomCollision has Failed\r\n");
            }
        }
    }
}
