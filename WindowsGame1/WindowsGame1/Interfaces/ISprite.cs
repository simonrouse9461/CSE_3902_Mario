using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface ISprite
    {
        void Initialize();
        void Reset();
        void Load(ContentManager content);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}