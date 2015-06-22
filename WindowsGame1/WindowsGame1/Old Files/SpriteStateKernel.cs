using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernel : ISpriteState
    {
        protected Counter Timer { get; set; }
        protected List<ISprite> SpriteList { get; set; }
        protected List<ColorAnimator> ColorAnimatorList { get; set; }

        public abstract ISprite Sprite { get; }

        public virtual Color Color
        {
            get { return Color.White; }
        }

        protected SpriteStateKernel()
        {
            Initialize();

            Timer = Timer ?? new Counter(5);
            SpriteList = SpriteList ?? new List<ISprite>();
            ColorAnimatorList = ColorAnimatorList ?? new List<ColorAnimator>();

            Reset();
        }

        protected abstract void Initialize();

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
            foreach (var colorAnimator in ColorAnimatorList)
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
            foreach (var colorAnimator in ColorAnimatorList)
            {
                colorAnimator.Update();
            }
        }
    }
}