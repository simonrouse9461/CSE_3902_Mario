using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class FireExplosion : ObjectKernelNew<FireExplosionStateController>, IFireball
    {
        public FireExplosion()
        {
            BarrierHandler = new FireExplosionBarrierHandler(Core);

            //BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<IMario>();
            BarrierHandler.RemoveBarrier<IEnemy>();
            BarrierHandler.RemoveBarrier<IFireball>();
        }

        public static FireExplosion BothSide
        {
            get
            {
                var instance = new FireExplosion();
                instance.Core.StateController.ToBoth();
                return instance;
            }
        }

        public static FireExplosion Single(ExplosionSize size)
        {
            var instance = new FireExplosion();
            instance.Core.StateController.Single(size);
            return instance;
        }

        public static FireExplosion LeftSide(ExplosionSize size)
        {
            var instance = new FireExplosion();
            instance.Core.StateController.ToLeft(size);
            return instance;
        }

        public static FireExplosion RightSide(ExplosionSize size)
        {
            var instance = new FireExplosion();
            instance.Core.StateController.ToRight(size);
            return instance;
        }
    }
}
