using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame
{
    public interface ISpriteStateNew
    {
        ISpriteNew Sprite { get; }
        Color Color { get; }
        Orientation Orientation { get; }
        IConvertible Version { get; }
        bool Left { get; }
        bool Right { get; }
        bool DefaultSprite { get; }
        bool Held { get; }

        void SetCore(ICoreNew c);
        void SetOrientation(Orientation orientation);
        void FaceLeft();
        void FaceRight();
        void FaceDefault();
        void Hold(bool holdOrientation, int timer = 0, Action action = null);
        void HoldTillFinish(bool holdOrientation, SpriteHoldDependency dependency, int cycle, Action action = null);
        void HoldTillFinish(bool holdOrientation, SpriteHoldDependency dependency, Action action = null);
        void HoldTillFinish(bool holdOrientation, int cycle = 1, Action action = null);
        void Release();
        void Load(ContentManager content);
        void SetSpriteFrequency(int frequency);
        void SetColorFrequency(int frequency);
        void SetVersionFrequency(int frequency);
        void Reset();
        void Update();
    }
}