
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
        public WorldManager World { get; private set; }
        private Texture2D Background;

        public MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            Controller = new CommandManager(this);
            World = WorldManager.Instance;
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Background = Content.Load<Texture2D>("overworld");
            World.LoadContent(Content);

            base.LoadContent();
        }

       
        protected override void UnloadContent()
        {
            
            base.UnloadContent();
        }

  
        protected override void Update(GameTime gameTime)
        {
            Controller.Update();
            World.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            World.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
