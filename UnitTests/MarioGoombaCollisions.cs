using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace MarioGoombaCollisions
{
    [TestClass]
    public class MarioGoombaCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private Goomba TestGoomba;
        private ContentManager Content;
        private ICommand TestCommand;
        [TestMethod]
        public void MarioGoombaRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestGoomba = TestGame.World.Goomba;
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            //Check if Mario is dead
            //Assert.AreEqual(true, TestMario.SpriteState.IsDead());
            //Check if Goomba is dead
            //Assert.AreEqual(GoombaSprite, TestGoomba.SpriteState);
        }

        public void MarioGoombaLeftCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestGoomba = TestGame.World.Goomba;
            TestCommand = new MarioLeftCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            //Check if Mario is dead
            //Assert.AreEqual(true, TestMario.SpriteState.IsDead());
            //Check if Goomba is dead
            //Assert.AreEqual(GoombaSprite, TestGoomba.SpriteState);
        }

        public void MarioGoombaTopCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestGoomba = TestGame.World.Goomba;
            TestCommand = new MarioDownCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            //Check if Mario is dead
            //Assert.AreEqual(false, TestMario.SpriteState.IsDead());
            //Check if Goomba is dead
            //Assert.AreEqual(DeadGoombaSprite, TestGoomba.SpriteState);
        }
        public void MarioGoombaBottomCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestGoomba = TestGame.World.Goomba;
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            //Check if Mario is dead
            //Assert.AreEqual(true, TestMario.SpriteState.IsDead());
            //Check if Goomba is dead
            //Assert.AreEqual(GoombaSprite, TestGoomba.SpriteState);
        }
    }
}

