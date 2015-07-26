﻿using System;
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

        public static FireExplosion LeftSide(IConvertible size)
        {
            var instance = new FireExplosion();
            instance.Core.StateController.ToLeft((ExplosionSize)size);
            return instance;
        }

        public static FireExplosion RightSide(IConvertible size)
        {
            var instance = new FireExplosion();
            instance.Core.StateController.ToRight((ExplosionSize)size);
            return instance;
        }
    }
}
