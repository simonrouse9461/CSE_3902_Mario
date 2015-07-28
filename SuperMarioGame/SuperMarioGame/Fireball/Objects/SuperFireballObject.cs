using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class SuperFireballObject : ObjectKernelNew<SuperFireballStateController>, IFireball
    {
        public SuperFireballObject()
        {
            BarrierHandler = new SuperFireballBarrierHandler(Core);
            CollisionHandler = new SuperFireballCollisionHandler(Core);
            BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<IEnemy>();
            BarrierHandler.RemoveBarrier<IMario>();
            BarrierHandler.RemoveBarrier<IItem>();
            BarrierHandler.RemoveBarrier<IFireball>();

            TurnUnsolid();
        }

        public static SuperFireballObject LeftSuperFireball
        {
            get
            {
                var instance = new SuperFireballObject();
                instance.Core.StateController.ToLeft();
                return instance;
            }
        }

        public static SuperFireballObject RightSuperFireball
        {
            get
            {
                var instance = new SuperFireballObject();
                instance.Core.StateController.ToRight();
                return instance;
            }
        }
       
    }
}
