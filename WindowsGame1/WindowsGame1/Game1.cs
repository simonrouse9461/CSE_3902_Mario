
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

        public MarioFireflowerCollisions MarioFireflowerCollisions;
        public MarioMushroomCollisions MarioMushroomCollisions;
        public MarioDestructibleBlockCollisions MarioDestructibleBlockCollisions;
        public MarioNormalBlockCollisions MarioNormalBlockCollisions;
        public MarioQuestionBlockCollisions MarioQuestionBlockCollisions;
        public MarioKoopaCollisions MarioKoopaCollisions;
        public MarioGoombaCollisions MarioGoombaCollisions;


        public MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void RunTests()
        {
            MarioFireflowerCollisions = new MarioFireflowerCollisions();
            MarioFireflowerCollisions.MarioFireflowerRightCollision(World, Content);
            MarioFireflowerCollisions.MarioFireflowerLeftCollision(World, Content);
            MarioFireflowerCollisions.MarioFireflowerTopCollision(World, Content);
            MarioFireflowerCollisions.MarioFireflowerBottomCollision(World, Content);
            MarioMushroomCollisions = new MarioMushroomCollisions();
            MarioMushroomCollisions.MarioMushroomRightCollision(World, Content);
            MarioMushroomCollisions.MarioMushroomLeftCollision(World, Content);
            MarioMushroomCollisions.MarioMushroomTopCollision(World, Content);
            MarioMushroomCollisions.MarioMushroomBottomCollision(World, Content);
            MarioMushroomCollisions.FireMarioMushroomBottomCollision(World, Content);
            MarioDestructibleBlockCollisions = new MarioDestructibleBlockCollisions();
            MarioDestructibleBlockCollisions.MarioDestructibleBlockRightCollision(World, Content);
            MarioDestructibleBlockCollisions.MarioDestructibleBlockLeftCollision(World, Content);
            MarioDestructibleBlockCollisions.MarioDestructibleBlockTopCollision(World, Content);
            MarioDestructibleBlockCollisions.MarioDestructibleBlockBottomCollision(World, Content);
            MarioNormalBlockCollisions = new MarioNormalBlockCollisions();
            MarioNormalBlockCollisions.MarioNormalBlockRightCollision(World, Content);
            MarioNormalBlockCollisions.MarioNormalBlockLeftCollision(World, Content);
            MarioNormalBlockCollisions.MarioNormalBlockTopCollision(World, Content);
            MarioNormalBlockCollisions.MarioNormalBlockBottomCollision(World, Content);
            MarioQuestionBlockCollisions = new MarioQuestionBlockCollisions();
            MarioQuestionBlockCollisions.MarioQuestionBlockRightCollision(World, Content);
            MarioQuestionBlockCollisions.MarioQuestionBlockLeftCollision(World, Content);
            MarioQuestionBlockCollisions.MarioQuestionBlockTopCollision(World, Content);
            MarioQuestionBlockCollisions.MarioQuestionBlockBottomCollision(World, Content);
            MarioKoopaCollisions = new MarioKoopaCollisions();
            MarioKoopaCollisions.MarioKoopaRightCollision(World, Content);
            MarioKoopaCollisions.MarioKoopaLeftCollision(World, Content);
            MarioKoopaCollisions.MarioKoopaTopCollision(World, Content);
            MarioKoopaCollisions.MarioKoopaBottomCollision(World, Content);
            MarioGoombaCollisions = new MarioGoombaCollisions();
            MarioGoombaCollisions.MarioGoombaRightCollision(World, Content);
            MarioGoombaCollisions.MarioGoombaLeftCollision(World, Content);
            MarioGoombaCollisions.MarioGoombaTopCollision(World, Content);
            MarioGoombaCollisions.MarioGoombaBottomCollision(World, Content);
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
            Camera.Update();

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
