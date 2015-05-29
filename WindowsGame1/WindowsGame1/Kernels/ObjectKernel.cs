using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel<T, K> : IObject<T, K>
        where T : struct, IConvertible
        where K : struct, IConvertible
    {
        protected ObjectState<T, K> State;

        // A Counter that defines update frequency
        protected Counter Counter;

        // Sprite information
        protected Dictionary<T, ISprite> Sprites;

        // Motion information
        protected Dictionary<K, ObjectMotion> Motions;

        protected ObjectKernel(Vector2 location)
        {
            Counter = new Counter();
            Initialize();
            Reset(location);
        }

        protected abstract void Initialize();

        public void Reset(Vector2 location)
        {
            State.Location = location;
            Counter.Reset();
            SwitchSprite(State.ActiveSprite);
            foreach (var motion in Motions)
            {
                ToggleMotion(motion.Key, false);
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
                State.Location += Motions[motionStatus.Key].GetValue();
            }
        }

        public void SwitchSprite(T sprite)
        {
            State.ActiveSprite = sprite;
            Sprites[sprite].Reset();
        }

        public void ToggleMotion(K motion, bool status)
        {
            State.EffectiveMotion[motion] = status;
            if (status)
                Motions[motion].Reset();
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