using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernel<EnemySpriteEnum, EnemyMotionEnum>
    {
        public  Goomba(Vector2 location) : base(location) { }


        protected override void Initialize()
        {
            State = new ObjectState<EnemySpriteEnum, EnemyMotionEnum>(default(Vector2));
            Sprites = new Dictionary<EnemySpriteEnum, ISprite>();
            Motions = new Dictionary<EnemyMotionEnum, ObjectMotion>();

            Sprites.Add(EnemySpriteEnum.Koopa, new GoombaSprite());
            Motions.Add(EnemyMotionEnum.leftRight, new ObjectMotion());

        }

        protected void Reset()
        {

        }
    }
}
