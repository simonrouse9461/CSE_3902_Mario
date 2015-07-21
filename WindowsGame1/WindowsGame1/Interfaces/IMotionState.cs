﻿using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotionState
    {
        ICoreNew Core { set; }
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        bool Frozen { get; }
        bool Static { get; }

        StatusSwitch<IMotion> FindMotion<T>(T motion = null) where T : class, IMotion, new();
        void Freeze(int timer = 0);
        void Restore();
        void Adjust(Vector2 offset);
        void Reset();
        void ResetHorizontalVelocity();
        void ResetVerticalVelocity();
        void Update();
    }
}