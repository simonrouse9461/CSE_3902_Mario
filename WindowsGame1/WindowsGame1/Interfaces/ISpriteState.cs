using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public interface ISpriteState
    {
        ISprite Sprite { get; }
        Color Color { get; }
        bool Left { get; }
        bool Right { get; }
        bool Frozen { get; }

        void Freeze();
        void Restore();
        void Load(ContentManager content);
        void ChangeSpriteFrequency(int frequency);
        void ChangeColorFrequency(int frequency);
        void Reset();
        void Update();
    }
}