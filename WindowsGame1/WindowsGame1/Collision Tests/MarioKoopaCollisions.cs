using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WindowsGame1;

namespace MarioKoopaCollisions
{
    public class MarioKoopaCollisions
    {
        private WorldManager TestWorld;
        private MarioGame TestGame;
        private MarioObject TestMario;
        private Koopa TestKoopa;
        private ContentManager Content;
        private ICommand TestCommand;

        
        public void MarioKoopaRightCollision()
        {
            TestGame = new MarioGame();
            TestWorld = TestGame.World;
            Content = TestGame.Content;
            TestMario = TestGame.World.Mario;
            TestKoopa = TestGame.World.Koopa;
            TestCommand = new MarioRightCommand(TestGame);
            TestMario.PassCommand(TestCommand);

            //Check if Mario is dead
            //Assert.AreEqual(true, TestMario.SpriteState.IsDead());
            //Check if Koopa is Shell
            //Assert.AreEqual(WalkingKoopaSprite, TestGoomba.SpriteState);
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

            //Check if Mario is dead
            //Assert.AreEqual(true, TestMario.SpriteState.IsDead());
            //Check if Koopa is Shell
            //Assert.AreEqual(WalkingKoopaSprite, TestGoomba.SpriteState);
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

            //Check if Mario is dead
            //Assert.AreEqual(true, TestMario.SpriteState.IsDead());
            //Check if Koopa is Shell
            //Assert.AreEqual(ShellKoopaSprite, TestGoomba.SpriteState);
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

            //Check if Mario is dead
            //Assert.AreEqual(true, TestMario.SpriteState.IsDead());
            //Check if Koopa is Shell
            //Assert.AreEqual(WalkingKoopaSprite, TestGoomba.SpriteState);
        }
    }
}
