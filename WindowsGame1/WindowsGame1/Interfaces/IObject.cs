using System;
using Microsoft.Xna.Framework;
 using Microsoft.Xna.Framework.Content;
 using Microsoft.Xna.Framework.Graphics;
 
 namespace MarioGame
 {
    public interface IObject
    {
        Rectangle CollisionRectangle { get; }
        Rectangle PositionRectangle { get; }
        Vector2 PositionPoint { get; }

        bool Solid { get; }
        bool Stealth { get; }
        bool GoingUp { get; }
        bool GoingDown { get; }
        bool GoingLeft { get; }
        bool GoingRight { get; }

        void Transform<T>(T obj = null) where T : class, IObject, new();
        void Generate<T>(Vector2 offset = default(Vector2), T obj = null) where T : class, IObject, new();
        void Generate<T>(T obj) where T : class, IObject, new();
        void PassCommand(ICommand command);

        void Reset();
        void Load(ContentManager content, Vector2 location);
        void Unload(bool immediate = false);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
 }