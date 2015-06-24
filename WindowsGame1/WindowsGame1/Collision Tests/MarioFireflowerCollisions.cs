using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace WindowsGame1
{
    public class MarioFireflowerCollisions
    {
        //private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario { get;  set; }
        private MarioObject CompareMario { get; set; }
        private Fireflower TestFireflower { get;  set; }
        
        private MarioSpriteState TestMarioSprite;
        private MarioMotionState TestMarioMotion;
        private MarioSpriteState CompareMarioSprite;
        private MarioMotionState CompareMarioMotion;
        private ICommand TestCommand;
        private ICommand CompareCommand;

       
        public void MarioFireflowerRightCollision(WorldManager world)
        {
            TestGame = new MarioGame();
            //TestWorld = new WorldManager();
            TestGame.Run();
            TestMario = new MarioObject(world);
            CompareMario = new MarioObject(world);
            TestFireflower = new Fireflower(world);
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

        public void MarioFireflowerLeftCollision(WorldManager world)
        {
            TestGame = new MarioGame();           
            TestMario = world.Mario;
            TestFireflower = world.Fireflower;
            TestCommand = new MarioLeftCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that Mario is now Fire Mario
            //Assert.AreEqual(true, TestMario.SpriteState.IsFire());
        }

        public void MarioFireflowerTopCollision(WorldManager world)
        {
            TestGame = new MarioGame();
            TestMario = world.Mario;
            TestFireflower = world.Fireflower;
            TestCommand = new MarioDownCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that Mario is now Fire Mario
            //Assert.AreEqual(true, TestMario.SpriteState.IsFire());
        }
        public void MarioFireflowerBottomCollision(WorldManager world)
        {
            TestGame = new MarioGame();
            TestMario = world.Mario;
            TestFireflower = world.Fireflower;
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that Mario is now Fire Mario
            //Assert.AreEqual(true, TestMario.SpriteState.IsFire());
        }
    }
}
