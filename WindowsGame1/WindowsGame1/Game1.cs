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
        private Texture2D Background;


        public MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Controller = new CommandManager(this);
            WorldManager.Initialize();
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Background = Content.Load<Texture2D>("overworld");
            WorldManager.LoadLevel(Content);

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            WorldManager.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
