using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    public class MarioGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private CommandManager Controller;
        public bool paused = false;

        public MarioGame()
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

            WorldManager.LoadLevel(Content);
            Display.LoadContent(Content);
            SoundManager.LoadAllSounds(Content);
            SoundManager.changeToOverworldMusic();
            base.LoadContent();
        }


        protected override void UnloadContent()
        {

            base.UnloadContent();
        }

        public void PauseGame()
        {
            paused = !paused;
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

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            WorldManager.Draw(spriteBatch);
            Display.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
