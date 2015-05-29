using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface IObject<T, K>
        where T : struct, IConvertible
        where K : struct, IConvertible
    {
        void Reset(Vector2 location);
        void Load(ContentManager content);
        void SwitchSprite(T sprite);
        void ToggleMotion(K motion, bool status);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}