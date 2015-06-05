﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernelNew : IObjectNew
    {
        protected ISpriteState SpriteState;

        protected IMotionState MotionState;

        protected ObjectKernelNew(Vector2 location)
        {
            Reset(location);
        }

        protected abstract void Initialize(Vector2 location);

        public void Reset(Vector2 location)
        {
            Initialize(location);
        }

        public void Load(ContentManager content)
        {
            SpriteState.Load(content);
        }

        public void Update()
        {
            SpriteState.Update();
            MotionState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteState.ActiveSprite().Draw(spriteBatch, MotionState.CurrentLocation());
        }
    }
}