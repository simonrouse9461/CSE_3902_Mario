using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class Display
    {
        private static Display _instance;

        private readonly Vector2 pscore;
        private readonly Vector2 pcoin;
        private readonly Vector2 plevel;
        private readonly Vector2 ptime;
        private readonly Vector2 ptimeup;

        private int _time;

        private int Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value <= 0 ? 0 : value;
                if (Time == 0)
                {
                    new MarioDeadCommand().Execute();
                    TimeUp = true;
                }
            }
        }

        private int MaxTime { get; set; }
        private int StartTime { get; set; }
        private int GameTime { get; set; }
        private bool TimeUp { get; set; }
        private int Score { get; set; }
        private int Coins { get; set; }
        private string Level { get; set; }
        private static SpriteFont Font { get; set; }

        private Display()
        {
            pscore = new Vector2 {X = 70, Y = 15};
            pcoin = new Vector2 {X = 270, Y = 15};
            plevel = new Vector2 {X = 470, Y = 15};
            ptime = new Vector2 {X = 670, Y = 15};
            ptimeup = new Vector2 {X = 305, Y = 195};
            Level = "1-1";
            MaxTime = 20;
        }

        private static Display Instance
        {
            get
            {
                Initialize();
                return _instance;
            }
        }

        public static void Initialize()
        {
            _instance = _instance ?? new Display();
        }

        public static void Reset()
        {
            Instance.StartTime = Instance.GameTime;
            Instance.TimeUp = false;
        }

        public static void LoadContent(ContentManager content)
        {
            Font = content.Load<SpriteFont>("SegoeUIMono");
            Font.LineSpacing = 20;
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
            Instance.GameTime = (int) gameTime.TotalGameTime.TotalSeconds;
            Instance.Time = Instance.MaxTime + Instance.StartTime - Instance.GameTime;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, "MARIO\n" + Instance.Score, Instance.pscore, Color.White);
            spriteBatch.DrawString(Font, "COIN\n" + Instance.Coins, Instance.pcoin, Color.White);
            spriteBatch.DrawString(Font, "WORLD\n" + Instance.Level, Instance.plevel, Color.White);
            spriteBatch.DrawString(Font, "TIME\n" + Instance.Time, Instance.ptime, Color.White);
            if (Instance.TimeUp) spriteBatch.DrawString(Font, "TIME IS UP!", Instance.ptimeup, Color.White);
        }
    }
}