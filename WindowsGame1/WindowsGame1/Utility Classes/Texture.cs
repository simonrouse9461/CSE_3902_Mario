using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WindowsGame1.Exceptions;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using LevelLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WindowsGame1
{
    public class Texture
    {
        private int time{set;get;}
        public int usedtime { set; get; }
        public int score;
        public int coins;
        public String level;


        public Vector2 pscore;
        private Vector2 pcoin;
        private Vector2 plevel;
        private Vector2 ptime;
        static SpriteFont georgia;
        private static Texture _instance;

        private Texture()
        {
            ptime.X = 600;
            ptime.Y = 0;
            pscore.X = 0;
            pscore.Y = 0;
            pcoin.X = 200;
            pcoin.Y = 0;
            plevel.X = 400;
            plevel.Y = 0;
            level = "1-1";
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

        public static void LoadContent(ContentManager Content)
        {
            georgia = Content.Load<SpriteFont>("GeorgiaFont");

        }

        public static void Increment(String obj)
        {
            if (obj.Equals("Mushroom")) { 
                Instance.score+=10;
            }
            if (obj.Equals("Coin")){
                Instance.score+=5;
                Instance.coins+=1;
            }
            if (obj.Equals("Fireflower")){
                Instance.score += 10;
            }
            if (obj.Equals("Koopa")||obj.Equals("Goomba"))
            {
                Instance.score += 100;
            }
        }
        public static void Update(GameTime gameTime)
        {
            Instance.time = gameTime.TotalGameTime.Seconds-10;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(georgia, "MARIO: " + Instance.score, Instance.pscore, Color.White);
            spriteBatch.DrawString(georgia, "COIN: " + Instance.coins, Instance.pcoin, Color.White);
            spriteBatch.DrawString(georgia, "WORLD: " + Instance.level, Instance.plevel, Color.White);
            spriteBatch.DrawString(georgia, "TIME: " + Instance.time, Instance.ptime, Color.White);


        }
    }
}