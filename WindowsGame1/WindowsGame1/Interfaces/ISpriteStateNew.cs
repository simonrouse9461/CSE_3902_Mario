using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public interface ISpriteStateNew
    {
        ICoreNew Core { set; }
        ISpriteNew Sprite { get; }
        Color Color { get; }
        Orientation Orientation { get; }
        IConvertible Version { get; }
        bool Left { get; }
        bool Right { get; }
        bool Default { get; }
        bool Held { get; }

        void SetVersion(IConvertible version);
        void SetOrientation(Orientation orientation);
        void ToLeft();
        void ToRight();
        void ToDefault();
        void Hold(int timer = 0);
        void Restore();
        void Load(ContentManager content);
        void SetSpriteFrequency(int frequency);
        void SetColorFrequency(int frequency);
        void Reset();
        void Update();
    }
}