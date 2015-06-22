using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace MarioDestructibleBlockCollisions
{
    [TestClass]
    public class MarioDestructibleBlockCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private DestructibleBlockObject TestBlock;
        private ContentManager Content;
        private ICommand TestCommand;
        [TestMethod]
        public void MarioDestructibleBlockRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestBlock = new DestructibleBlockObject(TestWorld);
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that block has not been destroyed
            Assert.AreEqual("DestructibleBlockSpriteState", TestBlock.SpriteState);
        }
        public void MarioDestructibleBlockLeftCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestBlock = new DestructibleBlockObject(TestWorld);
            TestCommand = new MarioLeftCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that block has not been destroyed
            Assert.AreEqual("DestructibleBlockSpriteState", TestBlock.SpriteState);
        }

        public void MarioDestructibleBlockTopCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestBlock = new DestructibleBlockObject(TestWorld);
            TestCommand = new MarioDownCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that block has not been destroyed
            Assert.AreEqual("DestructibleBlockSpriteState", TestBlock.SpriteState);
        }
        public void MarioDestructibleBlockBottomCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestBlock = new DestructibleBlockObject(TestWorld);
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check that block has been destroyed
            Assert.AreEqual(null, TestBlock.SpriteState);
        }
    }
}

