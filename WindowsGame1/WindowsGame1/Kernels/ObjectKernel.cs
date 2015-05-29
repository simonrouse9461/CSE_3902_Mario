using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel : IObject
    {
        protected IState State;

        // A Counter that defines update frequency
        protected Counter Counter;

        // Sprite information
        protected Dictionary<Enum, ISprite> Sprites;

        protected void SwitchSprite(Enum sprite)
        {
            State.ActiveSprite = sprite;
            Sprites[sprite].Reset();
        }

        // Motion information
        protected Dictionary<Enum, ObjectMotion> Motions;

        protected void ToggleMotion(Enum motion, bool status)
        {
            State.EffectiveMotion[motion] = status;
            if (status)
                Motions[motion].Reset();
        }

        protected ObjectKernel(Vector2 location)
        {
            Initialize();
            Reset(location);
        }

        protected abstract void Initialize();

        public void Reset(Vector2 location)
        {
            State.Location = location;
            Counter.Reset();
            SwitchSprite(State.ActiveSprite);
            foreach (var motionStatus in State.EffectiveMotion)
            {
                ToggleMotion(motionStatus.Key, false);
            }
        }

        public void Load(ContentManager content)
        {
            foreach (var sprite in Sprites)
            {
                sprite.Value.Load(content);
            }
        }

        protected void UpdateSprite()
        {
            Sprites[State.ActiveSprite].Update();
        }

        protected void UpdateLocation()
        {
            foreach (var motionStatus in State.EffectiveMotion)
            {
                if (motionStatus.Value)
                    Motions[motionStatus.Key].Update();
            }
        }

        public void Update()
        {
            if (Counter.Update())
            {
                UpdateSprite();
                UpdateLocation();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprites[State.ActiveSprite].Draw(spriteBatch, State.Location);
        }
    }
}