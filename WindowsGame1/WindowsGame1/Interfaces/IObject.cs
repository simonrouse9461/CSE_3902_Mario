using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface IObject
    {
        void Reset();

        void Load(ContentManager content);

        void Update();
        
        void Draw(SpriteBatch spriteBatch);

        void PassCommand(ICommand command);
        
        Rectangle GetPositionRectangle();
        
        Vector2 GetPositionPoint();
    }
}