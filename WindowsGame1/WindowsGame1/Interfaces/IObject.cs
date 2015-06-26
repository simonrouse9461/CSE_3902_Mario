using Microsoft.Xna.Framework;
 using Microsoft.Xna.Framework.Content;
 using Microsoft.Xna.Framework.Graphics;
 
 namespace WindowsGame1
 {
    public interface IObject
    {
        Rectangle PositionRectangle { get; }
        Vector2 PositionPoint { get; }
        bool Solid { get; }
        bool Stealth { get; }

        void Reset();
        void Load(ContentManager content, Vector2 location);
        void Unload(int unloadTimer = 0);
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void PassCommand(ICommand command);
    }
 }