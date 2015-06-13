using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernel : ISpriteState
    {
        protected Counter Timer;

        protected List<ISprite> SpriteList;

        protected SpriteStateKernel()
        {
            Initialize();

            Timer = Timer ?? new Counter();
            SpriteList = SpriteList ?? new List<ISprite>();

            Reset();
        }

        protected abstract void Initialize();

        public abstract ISprite ActiveSprite();

        public void Load(ContentManager content)
        {
            foreach (var sprite in SpriteList)
            {
                sprite.Load(content);
            }
        }

        public void Reset(int frequency = 10)
        {
            Timer.Reset(frequency);
            foreach (var sprite in SpriteList)
            {
                sprite.Reset();
            }
        }

        public void Update()
        {
            if (Timer.Update())
            {
                ActiveSprite().Update();
            }
        }
    }
}