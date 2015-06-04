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


        public IObject<MarioSpriteEnum, MarioMotionEnum> Mario;
        public IObject<BlockSpriteEnum, ItemMotionEnum> QuestionBlock;
        public IObject<ItemSpriteEnum, ItemMotionEnum> Mushroom;
        public IObject<ItemSpriteEnum, ItemMotionEnum> Fireflower;
        public IObject<EnemySpriteEnum, EnemyMotionEnum> Koopa;
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
            runningInPlaceCommand = new RunningInPlaceCommand(this);
            deadCommand = new DeadCommand(this);
            runningCommand = new RunningCommand(this);
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

            Mario = new MarioObject(new Vector2(400, 240));
            QuestionBlock = new BlockObject(new Vector2(300, 200));
            Fireflower = new ItemObject(new Vector2(400, 300));
            Mushroom = new ItemObject(new Vector2(500, 300));
            Koopa = new EnemyObject(new Vector2(300, 300));
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            background = Content.Load<Texture2D>("overworld");

            Mario.Load(Content);
            QuestionBlock.Load(Content);
            Mushroom.Load(Content);
            Fireflower.Load(Content);
            Koopa.Load(Content);
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

            Mario.Update();
            QuestionBlock.Update();
            Mushroom.Update();
            Fireflower.Update();
            Koopa.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

            Mario.Draw(spriteBatch);
            QuestionBlock.Draw(spriteBatch);
            Mushroom.Draw(spriteBatch);
            Fireflower.Draw(spriteBatch);
            Koopa.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
