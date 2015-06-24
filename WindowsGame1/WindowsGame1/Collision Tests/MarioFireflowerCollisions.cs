using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class MarioFireflowerCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario { get;  set; }
        private MarioObject CompareMario { get; set; }
        private Fireflower TestFireflower { get;  set; }
        private ContentManager Content;
        private MarioSpriteState TestMarioSprite;
        private MarioMotionState TestMarioMotion;
        private MarioSpriteState CompareMarioSprite;
        private MarioMotionState CompareMarioMotion;
        private ICommand TestCommand;
        private ICommand CompareCommand;

       
        public void MarioFireflowerRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestGame.Run();
            TestMario = new MarioObject(TestWorld);
            CompareMario = new MarioObject(TestWorld);
            TestFireflower = new Fireflower(TestWorld);
            CompareCommand = new MarioFireCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestCommand = new MarioRightCommand(TestGame);
            CompareCommand = new MarioRightCommand(TestGame);
            CompareMario.PassCommand(CompareCommand);
            TestMario.PassCommand(TestCommand);
            var TestState = TestMario.StateGetter;
            var CompareState = CompareMario.StateGetter;

            //Check that Mario is now Fire Mario
            if(TestState == CompareState)
            {
                Console.Write("MarioFireflowerRightCollision has Passed");
            }
            else
            {
                Console.Write("MarioFireflowerRightCollision has Failed");
            }
            
            
        }

        public void MarioFireflowerLeftCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestFireflower = TestGame.World.Fireflower;
            TestCommand = new MarioLeftCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that Mario is now Fire Mario
            //Assert.AreEqual(true, TestMario.SpriteState.IsFire());
        }

        public void MarioFireflowerTopCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestFireflower = TestGame.World.Fireflower;
            TestCommand = new MarioDownCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that Mario is now Fire Mario
            //Assert.AreEqual(true, TestMario.SpriteState.IsFire());
        }
        public void MarioFireflowerBottomCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestFireflower = TestGame.World.Fireflower;
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that Mario is now Fire Mario
            //Assert.AreEqual(true, TestMario.SpriteState.IsFire());
        }
    }
}
