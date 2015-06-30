using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernel : ISpriteState
    {
        protected Counter SpriteTimer { get; set; }
        protected Counter ColorTimer { get; set; }

        protected Collection<ISprite> SpriteList { get; set; }
        protected Collection<ColorAnimator> ColorSchemeList { get; set; }

        protected ISprite FindSprite<T>() where T : ISprite
        {
            return SpriteList.First(sprite => sprite is T);
        }

        public abstract ISprite Sprite { get; }

        protected virtual ColorAnimator ColorScheme { get { return null; } }

        public Color Color
        {
            get { return ColorScheme == null ? Color.White : ColorScheme.Color; }
        }

        public virtual bool Left { get { return false; } }

        public virtual bool Right { get { return false; } }


        protected SpriteStateKernel()
        {
            SpriteTimer = new Counter();
            ColorTimer = new Counter();
        }

        public void Load(ContentManager content)
        {
            foreach (var sprite in SpriteList)
            {
                sprite.Load(content);
            }
        }

        public void ChangeSpriteFrequency(int frequency)
        {
            SpriteTimer.Reset(frequency);
        }

        public void ChangeColorFrequency(int frequency)
        {
            ColorTimer.Reset(frequency);
        }
         
        public void Reset()
        {
            SpriteTimer.Reset();
            ColorTimer.Reset();
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
            if (SpriteTimer.Update())
            {
                Sprite.Update();
            }
            if (ColorTimer.Update() &&ColorSchemeList != null)
            {
                foreach (var colorAnimator in ColorSchemeList)
                {
                    colorAnimator.Update();
                }
            }
        }
    }
}