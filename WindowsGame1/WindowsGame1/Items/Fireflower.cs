using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernel<FireflowerSpriteEnum, FireflowerMotionEnum>
    {
        public Fireflower(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<FireflowerSpriteEnum, FireflowerMotionEnum>(default(Vector2));
            Sprites = new Dictionary<FireflowerSpriteEnum, ISprite>();
            Motions = new Dictionary<FireflowerMotionEnum, ObjectMotion>();

            Sprites.Add(FireflowerSpriteEnum.Fireflower, new FireflowerSprite());
            //Motions.Add(FireflowerMotionEnum.leftRight, new ObjectMotion());
        }
        protected void Reset()
        {

        }
    }
}
