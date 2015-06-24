using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace MarioMushroomCollisions
{
    public class MarioMushroomCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private Mushroom TestMushroom;
        private ContentManager Content;
        private ICommand TestCommand;

        public void MarioMushroomRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestMushroom = TestGame.World.Mushroom;
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);
            
            //Check if Mario is Big
            //Assert.AreEqual(true, TestMario.SpriteState.IsBig());
        }

        public void MarioMushroomLeftCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestMushroom = TestGame.World.Mushroom;
            TestCommand = new MarioLeftCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check if Mario is Big
            //Assert.AreEqual(true, TestMario.SpriteState.IsBig());
        }

        public void MarioMushroomTopCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestMushroom = TestGame.World.Mushroom;
            TestCommand = new MarioDownCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check if Mario is Big
            //Assert.AreEqual(true, TestMario.SpriteState.IsBig());
        }
        public void MarioMushroomBottomCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestMushroom = TestGame.World.Mushroom;
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check if Mario is Big
            //Assert.AreEqual(true, TestMario.SpriteState.IsBig());
        }
        public void FireMarioMushroomBottomCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            //TestMario.SpriteState.BecomeFire();
            TestMushroom = TestGame.World.Mushroom;
            TestCommand = new MarioUpCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check if Mario is still Fire Mario
            //Assert.AreEqual(true, TestMario.SpriteState.IsFire());
        }
    }
}
