using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private Koopa TestKoopa;
        private ContentManager Content;
        private ICommand TestCommand;

        [TestMethod]
        public void TestMethod1()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;

            TestKoopa = TestGame.World.Koopa;
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            Assert.AreEqual(null, TestGame.World.Mario);
        }
    }
}
