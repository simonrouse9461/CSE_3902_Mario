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
    // Haden added and editted this comment.
    
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private IController<Keys> _keyboardController;
        private IController<Buttons> _gamepadController;
        //Colin: Is this enum necessary?
        //Chuhan: I use this enum type to define the variable _currentSprite and _lastSprite, since it's more meaningful than just int.
        public enum Sprite
        {
            RunningInPlace,
            Dead,
            Running
        };

        private Sprite _currentSprite;
        private Sprite _lastSprite;
        internal Sprite CurrentSprite
        {
            get { return _currentSprite; }
            set
            {
                _lastSprite = _currentSprite;
                _currentSprite = value;
            }
        }
        
        private ISprite runningInPlaceMarioSprite;
        private ISprite deadMarioSprite;
        private ISprite runningMarioSprite;

        private Dictionary<Sprite, ISprite> spriteMapping;

        private ICommand quitCommand;
        private ICommand runningInPlaceCommand;
        private ICommand deadCommand;
        private ICommand runningCommand;

        private Texture2D background;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _keyboardController = new KeyboardController();
            _gamepadController = new GamepadController();

            CurrentSprite = Sprite.RunningInPlace;

            quitCommand = new QuitCommand(this);
            runningInPlaceCommand = new RunningInPlaceCommand(this);
            deadCommand = new DeadCommand(this);
            runningCommand = new RunningCommand(this);

            _keyboardController.RegisterCommand(Keys.Q, quitCommand);
            _keyboardController.RegisterCommand(Keys.W, runningInPlaceCommand);
            _keyboardController.RegisterCommand(Keys.E, deadCommand);
            _keyboardController.RegisterCommand(Keys.R, runningCommand);

            _gamepadController.RegisterCommand(Buttons.Back, quitCommand);
            _gamepadController.RegisterCommand(Buttons.A, runningInPlaceCommand);
            _gamepadController.RegisterCommand(Buttons.B, deadCommand);
            _gamepadController.RegisterCommand(Buttons.X, runningCommand);

            runningInPlaceMarioSprite = new RunningInPlaceMarioSprite();
            deadMarioSprite = new DeadMovingUpAndDownMarioSprite();
            runningMarioSprite = new RunningLeftAndRightMarioSprite();

            spriteMapping = new Dictionary<Sprite, ISprite>();
            spriteMapping.Add(Sprite.RunningInPlace, runningInPlaceMarioSprite);
            spriteMapping.Add(Sprite.Dead, deadMarioSprite);
            spriteMapping.Add(Sprite.Running, runningMarioSprite);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("stars");

            runningInPlaceMarioSprite.Load(Content);
            deadMarioSprite.Load(Content);
            runningMarioSprite.Load(Content);
        
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            _keyboardController.Update();
            _gamepadController.Update();

            spriteMapping[CurrentSprite].Update();
            if (CurrentSprite != _lastSprite)
            {
                spriteMapping[CurrentSprite].Reset();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

            spriteMapping[CurrentSprite].Draw(spriteBatch, new Vector2(400, 240));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
