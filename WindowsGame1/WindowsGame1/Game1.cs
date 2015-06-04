using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private IController<Keys> _keyboardController;
        private IController<Buttons> _gamepadController;


        //public IObject<MarioSpriteEnum, MarioMotionEnum> Mario;
        public IObject<BlockSpriteEnum, BlockMotionEnum> QuestionBlock;
        public IObject<FireflowerSpriteEnum, FireflowerMotionEnum> Fireflower;
        public IObject<MushroomSpriteEnum, MushroomMotionEnum> Mushroom;
        public IObject<_1upSpriteEnum, MushroomMotionEnum> _1up;
        public IObject<EnemySpriteEnum, EnemyMotionEnum> Koopa;
        public IObject<EnemySpriteEnum, EnemyMotionEnum> Goomba;
        private ICommand quitCommand;
        private ICommand runningInPlaceCommand;
        private ICommand deadCommand;
        private ICommand runningCommand;
        private ICommand questionBlockCommand;
        private ICommand fireflowerCommand;
        private ICommand mushroomCommand;
        private ICommand koopaCommand;

        private Texture2D background;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            
            _keyboardController = new KeyboardController();
            _gamepadController = new GamepadController();

            quitCommand = new QuitCommand(this);
            deadCommand = new DeadCommand(this);
            questionBlockCommand = new QuestionBlockCommand(this);
            mushroomCommand = new MushroomCommand(this);
            fireflowerCommand = new FireflowerCommand(this);
            koopaCommand = new KoopaCommand(this);

            _keyboardController.RegisterCommand(Keys.Q, quitCommand);
            _keyboardController.RegisterCommand(Keys.W, runningInPlaceCommand);
            _keyboardController.RegisterCommand(Keys.E, deadCommand);
            _keyboardController.RegisterCommand(Keys.R, runningCommand);
            _keyboardController.RegisterCommand(Keys.Z, questionBlockCommand);
            _keyboardController.RegisterCommand(Keys.K, koopaCommand);
            _keyboardController.RegisterCommand(Keys.M, mushroomCommand);
            _keyboardController.RegisterCommand(Keys.F, fireflowerCommand);

            _gamepadController.RegisterCommand(Buttons.Back, quitCommand);
            _gamepadController.RegisterCommand(Buttons.A, runningInPlaceCommand);
            _gamepadController.RegisterCommand(Buttons.B, deadCommand);
            _gamepadController.RegisterCommand(Buttons.X, runningCommand);

            //Mario = new MarioObject(new Vector2(400, 240));
            QuestionBlock = new BlockObject(new Vector2(300, 200));
            Fireflower = new Fireflower(new Vector2(400, 300));
            Mushroom = new Mushroom(new Vector2(500, 300));
            _1up = new _1up(new Vector2(600, 300));
            Koopa = new Koopa(new Vector2(300, 300));
            Goomba = new Goomba(new Vector2(340, 302));
            Goomba.SwitchSprite(EnemySpriteEnum.Goomba);
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            background = Content.Load<Texture2D>("overworld");

            //Mario.Load(Content);
            QuestionBlock.Load(Content);
            Mushroom.Load(Content);
            _1up.Load(Content);
            Fireflower.Load(Content);
            Koopa.Load(Content);
            Goomba.Load(Content);
            base.LoadContent();
        }

       
        protected override void UnloadContent()
        {
            

            base.UnloadContent();
        }

  
        protected override void Update(GameTime gameTime)
        {
            
            _keyboardController.Update();
            _gamepadController.Update();

            //Mario.Update();
            QuestionBlock.Update();
            Fireflower.Update();
            Mushroom.Update();
            _1up.Update();
            Koopa.Update();
            Goomba.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

            //Mario.Draw(spriteBatch);
            QuestionBlock.Draw(spriteBatch);
            Fireflower.Draw(spriteBatch);
            Mushroom.Draw(spriteBatch);
            _1up.Draw(spriteBatch);
            Koopa.Draw(spriteBatch);
            Goomba.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
