using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace MarioKoopaCollisions
{
    [TestClass]
    public class MarioKoopaCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private Koopa TestKoopa;
        private ContentManager Content;
        private ICommand TestCommand;

        [TestMethod]
        public void MarioKoopaRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestKoopa = TestGame.World.Koopa;
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            Assert.AreEqual(true, TestMario.SpriteState.IsDead());
        }

        public void MarioKoopaLeftCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestKoopa = TestGame.World.Koopa;
            TestCommand = new MarioLeftCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            Assert.AreEqual(true, TestMario.SpriteState.IsDead());
        }

        public void MarioKoopaTopCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestKoopa = TestGame.World.Koopa;
            TestCommand = new MarioDownCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            Assert.AreEqual(false, TestMario.SpriteState.IsDead());
        }
        public void MarioKoopaBottomCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestKoopa = TestGame.World.Koopa;
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            Assert.AreEqual(true, TestMario.SpriteState.IsDead());
        }
    }
}
