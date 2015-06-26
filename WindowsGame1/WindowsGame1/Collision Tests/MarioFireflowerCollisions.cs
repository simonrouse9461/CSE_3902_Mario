using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class MarioFireflowerCollisions
    {

        private MarioGame TestGame;
        private MarioObject TestMario { get; set; }
        private MarioObject CompareMario { get; set; }
        private Fireflower TestFireflower { get; set; }

//        private MarioSpriteState TestMarioSprite;
//        private MarioMotionState TestMarioMotion;
//        private MarioSpriteState CompareMarioSprite;
//        private MarioMotionState CompareMarioMotion;
        private ICommand TestCommand;
        private ICommand CompareCommand;

        public void MarioFireflowerRightCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestFireflower = new Fireflower();
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is now Fire Mario
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioFireflowerRightCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioFireflowerRightCollision has Failed\r\n");
            }


        }

        public void MarioFireflowerLeftCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestFireflower = new Fireflower();
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioLeftCommand(TestGame);
            CompareCommand = new MarioLeftCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is now Fire Mario
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioFireflowerLeftCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioFireflowerLeftCollision has Failed\r\n");
            }
        }

        public void MarioFireflowerTopCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestFireflower = new Fireflower();
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioUpCommand(TestGame);
            CompareCommand = new MarioUpCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is now Fire Mario
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioFireflowerUpCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioFireflowerUpCollision has Failed\r\n");
            }
        }
        public void MarioFireflowerBottomCollision(WorldManager world, ContentManager content)
        {
            TestGame = new MarioGame();
            TestMario = new MarioObject();
            CompareMario = new MarioObject();
            TestFireflower = new Fireflower();
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioDownCommand(TestGame);
            CompareCommand = new MarioDownCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is now Fire Mario
            if (TestState.Equals(CompareState))
            {
                Console.Write("MarioFireflowerBottomCollision has Passed\r\n");
            }
            else
            {
                Console.Write("MarioFireflowerBottomCollision has Failed\r\n");
            }
        }
    }
}
