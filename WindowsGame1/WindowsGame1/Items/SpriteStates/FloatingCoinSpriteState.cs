using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class FloatingCoinSpriteState : SpriteStateKernel
    {

        public FloatingCoinSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new FloatingCoinSprite(),
            };
            ChangeSpriteFrequency(10);
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<FloatingCoinSprite>();
            }
        }
        
    }
}
