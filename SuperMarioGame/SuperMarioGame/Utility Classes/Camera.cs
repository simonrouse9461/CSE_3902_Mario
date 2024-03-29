﻿using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public sealed class Camera
    {
        private Vector2 _location;
        private readonly Vector2 _screenSize;
        private readonly Collection<IObject> _objectList;
        private readonly static Camera Instance = new Camera();
        private bool _fixed;

        private Camera()
        {
            _location = default(Vector2);
            _screenSize = new Vector2(800, 480);
            _objectList = new Collection<IObject>();
        }

        public static bool Adjusted { get; private set; }

        public static Vector2 Location { get { return Instance._location; } }

        public static Vector2 ScreenSize { get { return Instance._screenSize; } }

        public static int Width { get { return (int)ScreenSize.X; } }

        public static int Height { get { return (int)ScreenSize.Y; } }

        public static Collection<IObject> ObjectList
        {
            get { return Instance._objectList; }
        }

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

        public static void Fix()
        {
            Instance._fixed = true;
        }

        public static void Release()
        {
            Instance._fixed = false;
        }

        public static void Adjust(Vector2 offset)
        {
            if (Instance._fixed) return;
            Instance._location += offset;
            Adjusted = true;
        }

        public static void Adjust(float x, float y = 0)
        {
            Adjust(new Vector2(x, y));
        }

        public static void Reset(Vector2 location = default(Vector2))
        {
            Instance._location = location;
            ClearObject();
            Release();
            Adjusted = true;
        }

        public static void Update()
        {
            Adjusted = false;
            var marioPosition = WorldManager.FindObject<Mario>().PositionPoint;
            if (marioPosition.X > Location.X + ScreenSize.X/2)
            {
                Adjust(marioPosition.X - Location.X - ScreenSize.X/2);
            }
        }

        public static void AddObject(IObject obj)
        {
            if (!ObjectList.Contains(obj))
                ObjectList.Add(obj);
        }

        public static void RemoveObject(IObject obj)
        {
            if (ObjectList.Contains(obj))
            {
                ObjectList.Remove(obj);
                WorldManager.RemoveObject(obj);
            }
        }

        public static void ClearObject()
        {
            ObjectList.Clear();
        }

        public static bool OutOfRange(IObject obj, Vector4 offset = default(Vector4))
        {
            return
                !obj.PositionRectangle.Intersects(ExtendedScreenRectangle(offset));
        }
    }
}