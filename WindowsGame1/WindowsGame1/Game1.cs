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
        SoundManager sound;

        private CommandManager Controller;
        private Texture2D Background;


        public MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            sound = new SoundManager();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Controller = new CommandManager(this);
            WorldManager.Initialize();
            Texture.Initialize();
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Background = Content.Load<Texture2D>("overworld");
            WorldManager.LoadLevel(Content);
            Texture.LoadContent(Content);
            SoundManager.music = Content.Load<SoundEffect>("music").CreateInstance();
            SoundManager.music.IsLooped = true;
            SoundManager.music.Play();

            base.LoadContent();
        }

       
        protected override void UnloadContent()
        {
            
            base.UnloadContent();
        }

  
        protected override void Update(GameTime gameTime)
        {
            Controller.Update();
            WorldManager.Update();
            Camera.Update();
            Texture.Update(gameTime);
            sound.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            WorldManager.Draw(spriteBatch);
            
            Texture.Draw(spriteBatch);            

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
