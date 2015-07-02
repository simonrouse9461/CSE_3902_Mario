﻿using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Camera
    {
        private static readonly Camera instance = new Camera(new Vector2(800, 480));

        private Camera(Vector2 size)
        {
            Location = default(Vector2);
            ScreenSize = size;
        }

        public static Camera Instance
        {
            get { return instance; }
        }

        public Vector2 Location { get; set; }
        public Vector2 ScreenSize { get; private set; }

        public void Adjust(Vector2 offset)
        {
            Location += offset;
        }

        public void Adjust(float x, float y = 0)
        {
            Location += new Vector2(x, y);
        }

        public void Update()
        {
            var marioPosition = WorldManager.FindObject<MarioObject>().PositionPoint;
            if (marioPosition.X > Location.X + ScreenSize.X/2)
            {
                Adjust(marioPosition.X - Location.X - ScreenSize.X/2);
            }
        }
    }
}