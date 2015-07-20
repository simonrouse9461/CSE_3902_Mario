﻿using System;
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

        void SetOrientation(Orientation orientation);
        void FaceLeft();
        void FaceRight();
        void FaceDefault();
        void Hold(bool holdOrientation, int timer = 0, Action action = null);
        void HoldTillFinish(bool holdOrientation, int cycle, Action action = null);
        void HoldTillFinish(bool holdOrientation, Action action = null);
        void Resume();
        void Load(ContentManager content);
        void SetSpriteFrequency(int frequency);
        void SetColorFrequency(int frequency);
        void SetVersionFrequency(int frequency);
        void Reset();
        void Update();
    }
}