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
        private MarioObject TestMario;
        private ContentManager Content;
        private CommandManager Controller;

        [TestMethod]
        public void TestMethod1()
        {
            TestWorld = new WorldManager();
            TestMario = new MarioObject(TestWorld);
            TestMario.Load(Content, new Vector2(200, 170));

        }
    }
}
