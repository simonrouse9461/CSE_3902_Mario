using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class SuperFireball : ObjectKernel<SuperFireballStateController>, IFireball
    {
        public SuperFireball()
        {
            BarrierHandler = new SuperFireballBarrierHandler(Core);
            CollisionHandler = new SuperFireballCollisionHandler(Core);
            BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<IEnemy>();
            BarrierHandler.RemoveBarrier<IMario>();
            BarrierHandler.RemoveBarrier<IItem>();
            BarrierHandler.RemoveBarrier<IFireball>();
            BarrierHandler.BecomeNonBarrier();
        }

        public static SuperFireball LeftSuperFireball
        {
            get
            {
                var instance = new SuperFireball();
                instance.Core.StateController.ToLeft();
                return instance;
            }
        }

        public static SuperFireball RightSuperFireball
        {
            get
            {
                var instance = new SuperFireball();
                instance.Core.StateController.ToRight();
                return instance;
            }
        }

        public bool Exploded { get { return StateController.SpriteState.Exploding; } }
    }
}
