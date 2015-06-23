using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernelNew : ISpriteStateNew
    {
        protected Counter UpdateTimer { get; set; }
        protected Collection<ISpriteNew> SpriteList { get; set; }
        protected Collection<ColorAnimator> ColorSchemeList { get; set; }

        protected ISpriteNew FindSprite<T>() where T : ISpriteNew
        {
            foreach (var sprite in SpriteList)
            {
                if (sprite is T) return sprite;
            }
            return null;
        }

        public abstract ISpriteNew Sprite { get; }

        public virtual Color Color { get { return Color.White; } }

        public virtual bool Left { get { return false; } }

        public virtual bool Right { get { return false; } }


        protected SpriteStateKernelNew()
        {
            UpdateTimer = new Counter();
        }

        public void Load(ContentManager content)
        {
            foreach (var sprite in SpriteList)
            {
                sprite.Load(content);
            }
        }

        public void ChangeFrequency(int frequency)
        {
            UpdateTimer.Reset(frequency);
        }
         
        public void Reset()
        {
            UpdateTimer.Reset();
            foreach (var sprite in SpriteList)
            {
                sprite.Reset();
            }
            foreach (var colorAnimator in ColorSchemeList)
            {
                colorAnimator.Reset();
            }
        }

        public void Update()
        {
            if (UpdateTimer.Update())
            {
                Sprite.Update();
            }
            foreach (var colorAnimator in ColorSchemeList)
            {
                colorAnimator.Update();
            }
        }
    }
}