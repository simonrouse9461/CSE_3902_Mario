using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernel : ISpriteState
    {
        protected Counter Timer;
        protected List<ISprite> SpriteList;

        protected SpriteStateKernel(int frequency = 10)
        {
            Reset(frequency);
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
            Timer = new Counter(frequency);
            Initialize();
        }

        public void Update()
        {
            ActiveSprite().Update();
        }

    }
}