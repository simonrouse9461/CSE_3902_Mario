using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class FireballSpriteState : SpriteStateKernel
    {
        private enum Fireball{
            Fireball,
            Exploded
        }
        private Fireball Status;

        public FireballSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new FireballSprite(),
                new ExplodingFireballSprite()
            };
            ChangeSpriteFrequency(7);
        }

        protected override ISprite RawSprite
        {
            get {
                if (Status == Fireball.Exploded)
                {
                    return FindSprite<ExplodingFireballSprite>();
                }
                else
                {
                    return FindSprite<FireballSprite>();
                }
            }
        }

        //public bool Fire
        //{
        //    get { return Status == Fireball.Fireball; }
        //}

        public void Exploded(){
            Status = Fireball.Exploded;
        }
    }
}
