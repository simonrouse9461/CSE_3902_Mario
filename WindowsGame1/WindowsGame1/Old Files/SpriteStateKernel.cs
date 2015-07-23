using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public abstract class SpriteStateKernel : ISpriteState
    {
        protected Counter SpriteTimer { get; set; }
        protected Counter ColorTimer { get; set; }

        protected Collection<ISprite> SpriteList { get; set; }

        protected ISprite FindSprite<T>() where T : ISprite
        {
            return SpriteList.First(sprite => sprite is T);
        }

        public ISprite Sprite
        {
            get { return Held ? FrozenSprite : RawSprite; }
        }

        protected abstract ISprite RawSprite { get; }
        private ISprite LastSprite { get; set; }
        private ISprite FrozenSprite { get; set; }
        

        public Color Color
        {
            get { return Color.White; }
        }

        public virtual bool Left { get { return false; } }

        public virtual bool Right { get { return false; } }

        public bool Held { get; private set; }

        protected SpriteStateKernel()
        {
            SpriteTimer = new Counter();
            ColorTimer = new Counter();
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
        }

        public virtual void Update()
        {
            if (LastSprite != null && LastSprite != Sprite) LastSprite.Reset();
            if (SpriteTimer.Update()) Sprite.Update();
            LastSprite = Sprite;
        }
    }
}