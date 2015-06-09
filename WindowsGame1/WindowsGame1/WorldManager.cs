using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class WorldManager
    {
        public MarioObject Mario;
        public GoombaObject Goomba;
        public CoinObject Coin;
        public StarObject Star;
        public Koopa Koopa;
        public Fireflower Fireflower;
        public _1up _1up;
        public Mushroom Mushroom;
        public QuestionBlockObject QuestionBlock;
        public HiddenBlockObject HiddenBlock;
        public NormalBlockObject NormalBlock;
        public DestructibleBlockObject DestructibleBlock;
        public IndestructibleBlockObject IndestructibleBlock;
        public UsedBlockObject UsedBlock;
        public GreenPipeObject GreenPipe;

        public WorldManager()
        {
            Mario = new MarioObject(new Vector2(200, 100));
            Goomba = new GoombaObject(new Vector2(240, 302));
            Coin = new CoinObject(new Vector2(450, 300));
            Star = new StarObject(new Vector2(500, 300));
            QuestionBlock = new QuestionBlockObject(new Vector2(300, 200));
            HiddenBlock = new HiddenBlockObject(new Vector2(200, 200));
            NormalBlock = new NormalBlockObject(new Vector2(100, 200));
            DestructibleBlock = new DestructibleBlockObject(new Vector2(350, 200));
            IndestructibleBlock = new IndestructibleBlockObject(new Vector2(150, 200));
            GreenPipe = new GreenPipeObject(new Vector2(500, 200));
            UsedBlock = new UsedBlockObject(new Vector2(250, 200));
            Fireflower = new Fireflower(new Vector2(400, 304));
            Mushroom = new Mushroom(new Vector2(550, 300));
            _1up = new _1up(new Vector2(600, 300));
            Koopa = new Koopa(new Vector2(200, 300));
        }

        public void LoadContent(ContentManager content)
        {
            Mario.Load(content);
            QuestionBlock.Load(content);
            UsedBlock.Load(content);
            NormalBlock.Load(content);
            HiddenBlock.Load(content);
            IndestructibleBlock.Load(content);
            DestructibleBlock.Load(content);
            GreenPipe.Load(content);
            Mushroom.Load(content);
            _1up.Load(content);
            Fireflower.Load(content);
            Coin.Load(content);
            Star.Load(content);
            Koopa.Load(content);
            Goomba.Load(content);
        }

        public void Update()
        {
            Mario.Update();
            QuestionBlock.Update();
            Fireflower.Update();
            Coin.Update();
            Star.Update();
            Mushroom.Update();
            _1up.Update();
            Koopa.Update();
            Goomba.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Mario.Draw(spriteBatch);
            QuestionBlock.Draw(spriteBatch);
            UsedBlock.Draw(spriteBatch);
            NormalBlock.Draw(spriteBatch);
            HiddenBlock.Draw(spriteBatch);
            IndestructibleBlock.Draw(spriteBatch);
            DestructibleBlock.Draw(spriteBatch);
            GreenPipe.Draw(spriteBatch);
            Fireflower.Draw(spriteBatch);
            Coin.Draw(spriteBatch);
            Star.Draw(spriteBatch);
            Mushroom.Draw(spriteBatch);
            _1up.Draw(spriteBatch);
            Koopa.Draw(spriteBatch);
            Goomba.Draw(spriteBatch);
        }
    }
}