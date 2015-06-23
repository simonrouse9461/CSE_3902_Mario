using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernelNew : ISpriteStateNew
    {
        protected Counter Timer { get; set; }
        protected Collection<ISpriteNew> SpriteList { get; set; }
        protected Collection<ColorAnimator> ColorSchemeList { get; set; }

        protected ISpriteNew FindSprite<T>() where T : ISpriteNew
        {
            return SpriteList.First(sprite => sprite is T);
        }

        public abstract ISpriteNew Sprite { get; }

        public virtual Color Color { get { return Color.White; } }

        public virtual bool Left { get { return false; } }

        public virtual bool Right { get { return false; } }


        protected SpriteStateKernelNew()
        {
            Timer = new Counter();
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
            Timer.Reset(frequency);
        }
         
        public void Reset()
        {
            Timer.Reset();
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
            if (Timer.Update())
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