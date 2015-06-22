using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace MarioFireflowerCollisions
{
    [TestClass]
    public class MarioFireflowerCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private Fireflower TestFireflower;
        private ContentManager Content;
        private ICommand TestCommand;

        [TestMethod]
        public void MarioFireflowerRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestFireflower = TestGame.World.Fireflower;
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that Mario is now Fire Mario
            Assert.AreEqual(true, TestMario.SpriteState.IsFire());
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
            Assert.AreEqual(true, TestMario.SpriteState.IsFire());
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
            Assert.AreEqual(true, TestMario.SpriteState.IsFire());
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
            Assert.AreEqual(true, TestMario.SpriteState.IsFire());
        }
    }
}
