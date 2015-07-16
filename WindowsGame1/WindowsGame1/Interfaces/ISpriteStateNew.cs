using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public interface ISpriteStateNew
    {
        ISpriteNew Sprite { get; }
        Color Color { get; }
        Orientation Orientation { get; }
        bool Left { get; }
        bool Right { get; }
        bool Default { get; }
        bool Held { get; }

        void Hold();
        void Restore();
        void Load(ContentManager content);
        void SetSpriteFrequency(int frequency);
        void SetColorFrequency(int frequency);
        void Reset();
        void Update();
    }
}