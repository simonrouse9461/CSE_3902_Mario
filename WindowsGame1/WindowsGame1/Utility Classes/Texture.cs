using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class Texture
    {
        private static Texture _instance;

        private readonly Vector2 pscore;
        private readonly Vector2 pcoin;
        private readonly Vector2 plevel;
        private readonly Vector2 ptime;

        private int Time { get; set; }
        private int MaxTime { get; set; }
        private int Score { get; set; }
        private int Coins { get; set; }
        private string Level { get; set; }
        private static SpriteFont Font { get; set; }

        private Texture()
        {
            ptime = new Vector2 {X = 600, Y = 15};
            pscore = new Vector2 {X = 50, Y = 15};
            pcoin = new Vector2 {X = 230, Y = 15};
            plevel = new Vector2 {X = 400, Y = 15};
            Level = "1-1";
            MaxTime = 300;
        }

        private static Texture Instance
        {
            get
            {
                Initialize();
                return _instance;
            }
        }

        public static void Initialize()
        {
            _instance = _instance ?? new Texture();
        }

        public static void LoadContent(ContentManager content)
        {
            Font = content.Load<SpriteFont>("SegoeUIMono");
        }

        public static void Increment<T>() where T : IObject
        {
            if (typeof (Mushroom).IsAssignableFrom(typeof (T)))
            {
                Instance.Score += 10;
            }
            if (typeof (Coin).IsAssignableFrom(typeof (T)))
            {
                Instance.Score += 5;
                Instance.Coins += 1;
            }
            if (typeof (Fireflower).IsAssignableFrom(typeof (T)))
            {
                Instance.Score += 10;
            }
            if (typeof (IEnemy).IsAssignableFrom(typeof (T)))
            {
                Instance.Score += 100;
            }
        }

        public static void Update(GameTime gameTime)
        {
            Instance.Time = Instance.MaxTime - gameTime.TotalGameTime.Seconds;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, "MARIO: " + Instance.Score, Instance.pscore, Color.White);
            spriteBatch.DrawString(Font, "COIN: " + Instance.Coins, Instance.pcoin, Color.White);
            spriteBatch.DrawString(Font, "WORLD: " + Instance.Level, Instance.plevel, Color.White);
            spriteBatch.DrawString(Font, "TIME: " + Instance.Time, Instance.ptime, Color.White);
        }
    }
}