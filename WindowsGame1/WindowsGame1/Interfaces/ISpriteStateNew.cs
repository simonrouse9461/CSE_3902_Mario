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

        ISpriteNew FindSprite<T>() where T : ISpriteNew;
        void SetSprite<T>() where T : ISpriteNew;
        bool IsSprite<T>() where T : ISpriteNew;
        void SetVersion(IConvertible version);
        void SetOrientation(Orientation orientation);
        void ToLeft();
        void ToRight();
        void ToDefault();
        void Hold(bool holdOrientation, int timer = 0, Action action = null);
        void HoldTillFinish(bool holdOrientation, int cycle, Action action = null);
        void HoldTillFinish(bool holdOrientation, Action action = null);
        void Resume();
        void Load(ContentManager content);
        void SetSpriteFrequency(int frequency);
        void SetColorFrequency(int frequency);
        void Reset();
        void Update();
    }
}