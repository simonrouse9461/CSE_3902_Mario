using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernelNew : ISpriteState
    {
        protected Counter UpdateTimer { get; set; }
        protected List<ISprite> SpriteList { get; set; }
        protected List<ColorAnimator> ColorSchemeList { get; set; }

        public abstract ISprite Sprite { get; }

        public virtual Color Color
        {
            get { return Color.White; }
        }

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