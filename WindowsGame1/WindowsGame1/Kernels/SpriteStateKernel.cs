using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernel : ISpriteState
    {
        protected Counter Timer { get; set; }
        protected List<ISprite> SpriteList { get; set; }

        public abstract ISprite Sprite { get; }

        protected SpriteStateKernel()
        {
            Initialize();

            Timer = Timer ?? new Counter(5);
            SpriteList = SpriteList ?? new List<ISprite>();

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

        public void UpdateFrequency(int frequency)
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
        }

        public void Update()
        {
            if (Timer.Update())
            {
                Sprite.Update();
            }
        }
    }
}