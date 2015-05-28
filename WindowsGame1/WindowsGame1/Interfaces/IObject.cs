using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface IObject
    {
        void Initialize();
        void Reset(Vector2 location);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}