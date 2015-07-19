using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public interface ISpriteNew
    {
        int Cycle { get; }
        IConvertible Version { get; }

        void SetVersion(IConvertible version);
        void Reset();
        void Load(ContentManager content);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Orientation orientation, Color? color = null);
        Rectangle GetDestination(Vector2 position);
        Vector2 GetLocation(Vector2 position);
    }
}