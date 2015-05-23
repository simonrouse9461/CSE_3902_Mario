using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface ISprite
    {
        void Load(ContentManager Content);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}