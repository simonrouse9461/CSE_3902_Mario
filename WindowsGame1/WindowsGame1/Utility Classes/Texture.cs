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
        public Vector2 score;
        private Vector2 coin;
        private Vector2 level;
        private Vector2 pos;
        static SpriteFont georgia;
        private static Texture _instance;

        private Texture()
        {
            score.X = 0;
            score.Y = 0;
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

        public static void Update()
        {

        }

        public static void Draw(SpriteBatch spriteBatch,GameTime gameTime)
        {
            spriteBatch.DrawString(georgia, "time: " + gameTime.TotalGameTime.Seconds, Instance.score, Color.Red);
        }
    }
}