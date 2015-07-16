using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernelNew : ISpriteStateNew
    {
        protected Counter SpriteTimer { get; set; }
        protected Counter ColorTimer { get; set; }

        protected Dictionary<int, ISpriteNew> SpriteList { get; set; }
        protected Collection<ColorAnimator> ColorSchemeList { get; set; }

        protected ISpriteNew FindSprite<T>() where T : ISpriteNew
        {
            return SpriteList.First(sprite => sprite.Value is T).Value;
        }

        public ISpriteNew Sprite
        {
            get { return Held ? FrozenSprite : RawSprite; }
        }

        protected abstract ISpriteNew RawSprite { get; }
        private ISpriteNew LastSprite { get; set; }
        private ISpriteNew FrozenSprite { get; set; }
        

        protected virtual ColorAnimator ColorScheme { get { return null; } }

        public Color Color
        {
            get { return ColorScheme == null ? Color.White : ColorScheme.Color; }
        }

        public Orientation Orientation { get; protected set; }
        public bool Left { get { return Orientation == Orientation.Left; } }
        public bool Right { get { return Orientation == Orientation.Right; } }
        public bool Default { get { return Orientation == Orientation.Default; } }
        public bool Held { get; private set; }

        protected SpriteStateKernelNew()
        {
            SpriteTimer = new Counter();
            ColorTimer = new Counter();
            Orientation = Orientation.Default;
        }

        public void Hold()
        {
            FrozenSprite = Sprite;
            Held = true;
        }

        public void Restore()
        {
            Held = false;
        }

        public void Load(ContentManager content)
        {
            foreach (var sprite in SpriteList)
            {
                sprite.Value.Load(content);
            }
        }

        public void SetSpriteFrequency(int frequency)
        {
            SpriteTimer.Reset(frequency);
        }

        public void SetColorFrequency(int frequency)
        {
            ColorTimer.Reset(frequency);
        }
         
        public void Reset()
        {
            SpriteTimer.Reset();
            ColorTimer.Reset();
            foreach (var sprite in SpriteList)
            {
                sprite.Value.Reset();
            }
            foreach (var colorAnimator in ColorSchemeList)
            {
                colorAnimator.Reset();
            }
        }

        public virtual void Update()
        {
            if (LastSprite != null && LastSprite != Sprite) LastSprite.Reset();
            if (SpriteTimer.Update()) Sprite.Update();
            if (ColorTimer.Update() &&ColorSchemeList != null)
            {
                foreach (var colorAnimator in ColorSchemeList)
                {
                    colorAnimator.Update();
                }
            }
            LastSprite = Sprite;
        }
    }
}