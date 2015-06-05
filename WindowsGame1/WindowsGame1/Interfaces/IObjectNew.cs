using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface IObjectNew
    {
        void Reset(Vector2 location);
        void Load(ContentManager content);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}