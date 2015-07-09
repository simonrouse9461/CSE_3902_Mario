﻿using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public sealed class Camera
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

        public static Vector2 Location { get; set; }
        public static Vector2 ScreenSize { get; private set; }

        public static Rectangle ScreenRectangle
        {
            get
            {
                return new Rectangle((int) Location.X, (int) Location.Y , (int) ScreenSize.X,
                    (int) ScreenSize.Y);
            }
        }

        public static Rectangle ExtendedScreenRectangle(Vector4 offset)
        {
            return new Rectangle((int) (Location.X - offset.X), (int) (Location.Y - offset.Y),
                (int) (ScreenSize.X + offset.X + offset.Z),
                (int) (ScreenSize.Y + offset.Y + offset.W));
        }

        public static void Adjust(Vector2 offset)
        {
            Location += offset;
        }

        public static void Adjust(float x, float y = 0)
        {
            Location += new Vector2(x, y);
        }

        public static void Reset(Vector2 location = default(Vector2))
        {
            Location = location;
        }

        public static void Update()
        {
            var marioPosition = WorldManager.FindObject<MarioObject>().PositionPoint;
            if (marioPosition.X > Location.X + ScreenSize.X/2)
            {
                Adjust(marioPosition.X - Location.X - ScreenSize.X/2);
            }
        }

        public static bool OutOfRange(IObject obj, Vector4 offset = default(Vector4))
        {
            return
                !obj.PositionRectangle.Intersects(ExtendedScreenRectangle(offset));
        }
    }
}