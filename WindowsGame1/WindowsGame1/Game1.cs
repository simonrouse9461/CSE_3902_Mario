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
    // Haden added this comment.
    
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D texture;

        private IController<Keys> keyboardController;
        private IController<Buttons> gamepadController;
        //Colin: Is this enum necessary?
        //Chuhan: I use this enum type to define the variable currentSprite and lastSprite, since it's more meaningful than just int.
        public enum Sprite
        {
            runningInPlace,
            dead,
            running
        };

        private Sprite _currentSprite;
        internal Sprite currentSprite
        {
            get { return _currentSprite; }
            set
            {
                lastSprite = _currentSprite;
                _currentSprite = value;
            }
        }
        private Sprite lastSprite;

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
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();

            currentSprite = Sprite.runningInPlace;

            quitCommand = new QuitCommand(this);
            runningInPlaceCommand = new RunningInPlaceCommand(this);
            deadCommand = new DeadCommand(this);
            runningCommand = new RunningCommand(this);

            keyboardController.RegisterCommand(Keys.Q, quitCommand);
            keyboardController.RegisterCommand(Keys.W, runningInPlaceCommand);
            keyboardController.RegisterCommand(Keys.E, deadCommand);
            keyboardController.RegisterCommand(Keys.R, runningCommand);

            gamepadController.RegisterCommand(Buttons.Back, quitCommand);
            gamepadController.RegisterCommand(Buttons.A, runningInPlaceCommand);
            gamepadController.RegisterCommand(Buttons.B, deadCommand);
            gamepadController.RegisterCommand(Buttons.X, runningCommand);

            runningInPlaceMarioSprite = new RunningInPlaceMarioSprite();
            deadMarioSprite = new DeadMovingUpAndDownMarioSprite();
            runningMarioSprite = new RunningLeftAndRightMarioSprite();

            spriteMapping = new Dictionary<Sprite, ISprite>();
            spriteMapping.Add(Sprite.runningInPlace, runningInPlaceMarioSprite);
            spriteMapping.Add(Sprite.dead, deadMarioSprite);
            spriteMapping.Add(Sprite.running, runningMarioSprite);

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
            texture = Content.Load<Texture2D>("mario");

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
            keyboardController.Update();
            gamepadController.Update();

            spriteMapping[currentSprite].Update();
            if (currentSprite != lastSprite)
            {
                spriteMapping[currentSprite].Reset();
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

            spriteMapping[currentSprite].Draw(spriteBatch, new Vector2(400, 240));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
