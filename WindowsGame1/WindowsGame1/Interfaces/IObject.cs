using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface IObject
    {
        void Reset(Vector2 location);
        void Load(ContentManager content);
        void SwitchSprite(Enum sprite);
        void ToggleMotion(Enum motion, bool status);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}