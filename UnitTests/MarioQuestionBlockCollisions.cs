using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace MarioQuestionBlockCollisions
{
    [TestClass]
    public class MarioQuestionBlockCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private QuestionBlockObject TestBlock;
        private ContentManager Content;
        private ICommand TestCommand;
        [TestMethod]
        public void MarioQuestionBlockRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            //TestBlock = TestGame.World.QuestionBlockObject;
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            //Check that question block is not changed
            //Assert.AreEqual(QuestionBlockSpriteState, TestBlock.SpriteState);
        }
        public void MarioQuestionBlockLeftCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            //TestBlock = TestGame.World.QuestionBlockObject;
            TestCommand = new MarioLeftCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check that question block is not changed
            //Assert.AreEqual(QuestionBlockSpriteState, TestBlock.SpriteState);
        }

        public void MarioQuestionBlockTopCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            //TestBlock = TestGame.World.QuestionBlockObject;
            TestCommand = new MarioDownCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check that question block is not changed
            //Assert.AreEqual(QuestionBlockSpriteState, TestBlock.SpriteState);
        }
        public void MarioQuestionBlockBottomCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            //TestBlock = TestGame.World.QuestionBlockObject;
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check that question block is now used block
            //Assert.AreEqual(UsedBlockSpriteState, TestBlock.SpriteState);
        }
    }
}