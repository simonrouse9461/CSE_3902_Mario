using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace MarioNormalBlockCollisions
{
    public class MarioNormalBlockCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private NormalBlockObject TestBlock;
        private ContentManager Content;
        private ICommand TestCommand;
     
        public void MarioNormalBlockRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestBlock = new NormalBlockObject(TestWorld);
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            //Check that block has not been broken
            //Assert.AreEqual("NormalBlockSpriteState", TestBlock.SpriteState);
        }
        public void MarioNormalBlockLeftCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestBlock = new NormalBlockObject(TestWorld);
            TestCommand = new MarioLeftCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check that block has not been broken
            //Assert.AreEqual("NormalBlockSpriteState", TestBlock.SpriteState);
        }

        public void MarioNormalBlockTopCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestBlock = new NormalBlockObject(TestWorld);
            TestCommand = new MarioDownCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check that block has not been broken
            //Assert.AreEqual("NormalBlockSpriteState", TestBlock.SpriteState);
        }
        public void MarioNormalBlockBottomCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestBlock = new NormalBlockObject(TestWorld);
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check that block has disappeared
            //Assert.AreEqual(null, TestBlock.SpriteState);
        }
    }
}

