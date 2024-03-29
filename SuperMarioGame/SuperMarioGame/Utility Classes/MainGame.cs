using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperMario
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private int pauseCountdown = 5;
        //private int MarioLives = 3;
        //private bool SplashScreen = true;
        private CommandManager Controller;
        private bool paused = false;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Controller = new CommandManager(this);
            WorldManager.Initialize();
            Display.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SoundManager.LoadAllSounds(Content);
            WorldManager.LoadLevel(Content);
            Display.LoadContent(Content);
            base.LoadContent();
        }


        protected override void UnloadContent()
        {

            base.UnloadContent();
        }

        public void PauseGame()
        {
            if (paused)
            {
                if (pauseCountdown == 5)
                {
                    paused = false;
                    SoundManager.SwitchToOverworldMusic();
                }
            }
            else
            {
                if (pauseCountdown == 5)
                {
                    paused = true;
                    SoundManager.CoinSoundPlay();
                    SoundManager.StopMusic();
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            Controller.Update();
            if (!paused)
            {
                WorldManager.Update();
                Camera.Update();
                Display.Update(gameTime);
                base.Update(gameTime);
            }
            
            if (pauseCountdown == 0)
            {
                pauseCountdown = 5;
            }
            else
            {
                pauseCountdown--;
            }

        }

        protected override void Draw(GameTime gameTime)
        {
                spriteBatch.Begin(SpriteSortMode.Immediate, null, GameSettings.TextureSampling, null, null);

                WorldManager.Draw(GraphicsDevice, spriteBatch);
                Display.Draw(spriteBatch);

                spriteBatch.End();
                base.Draw(gameTime);
        }
    }
}
