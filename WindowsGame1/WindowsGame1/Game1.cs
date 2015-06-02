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
        public IObject<BlockSpriteEnum, BlockMotionEnum> QuestionBlock;
        private ICommand quitCommand;
        private ICommand runningInPlaceCommand;
        private ICommand deadCommand;
        private ICommand runningCommand;
        private ICommand questionBlockCommand;

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

            _keyboardController.RegisterCommand(Keys.Q, quitCommand);
            _keyboardController.RegisterCommand(Keys.W, runningInPlaceCommand);
            _keyboardController.RegisterCommand(Keys.E, deadCommand);
            _keyboardController.RegisterCommand(Keys.R, runningCommand);
            _keyboardController.RegisterCommand(Keys.Z, questionBlockCommand);

            _gamepadController.RegisterCommand(Buttons.Back, quitCommand);
            _gamepadController.RegisterCommand(Buttons.A, runningInPlaceCommand);
            _gamepadController.RegisterCommand(Buttons.B, deadCommand);
            _gamepadController.RegisterCommand(Buttons.X, runningCommand);

            Mario = new MarioObject(new Vector2(400, 240));
            QuestionBlock = new BlockObject(new Vector2(300, 200));

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            background = Content.Load<Texture2D>("stars");

            Mario.Load(Content);
            QuestionBlock.Load(Content);
        
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

            Mario.Draw(spriteBatch);
            QuestionBlock.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
