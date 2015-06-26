using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface ISprite
    {
        void Reset();
        void Load(ContentManager content);
        void Update();
        void DrawLeft(SpriteBatch spriteBatch, Vector2 location, Color? color = null);
        void DrawRight(SpriteBatch spriteBatch, Vector2 location, Color? color = null);
        void DrawDefault(SpriteBatch spriteBatch, Vector2 location, Color? color = null);
        Rectangle GetDestination(Vector2 location);
    }
}