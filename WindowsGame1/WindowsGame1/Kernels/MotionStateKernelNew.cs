﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernelNew : IMotionState
    {
        protected Counter Timer { get; set; }
        protected Collection<StatusSwitch<IMotion>> MotionList { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public void Adjust(Vector2 offset)
        {
            Position += offset;
        }

        protected MotionStateKernelNew()
        {
            Timer =  new Counter();
            Velocity = default(Vector2);
        }

        protected StatusSwitch<IMotion> FindMotion<T>(T motion = null) where T : class, IMotion, new()
        {
            return motion == null
                ? MotionList.First(m => m.Content is T)
                : MotionList.First(m => motion.SameVersion(m.Content));
        }
        
        public void Reset()
        {
            Timer.Reset();
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.Reset());
            }
        }

        public void ResetHorizontalVelocity()
        {
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.ResetX());
            }
        }

        public void ResetVerticalVelocity()
        {
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.ResetY());
            }
        }

        public void Update()
        {
            if (MotionList == null) return;
            if (Timer.Update())
            {
                Velocity = default(Vector2);

                foreach (var motion in MotionList)
                {
                    if (motion.Content.Finish) motion.Toggle(false);
                    if (motion.Status)
                    {
                        motion.Content.Update();
                        Velocity += motion.Content.Velocity;
                    }
                    else motion.Reset(m => m.Reset());
                }

                foreach (var motion in MotionList)
                {
                    motion.Content.SetCurrentVelocity(Velocity);
                    if (!motion.Status) motion.Reset(m => m.SetInitialVelocity(Velocity));
                }

                Position += Velocity;
            }
        }
    }
}