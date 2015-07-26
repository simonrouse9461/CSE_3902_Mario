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
            BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<IEnemy>();
            BarrierHandler.RemoveBarrier<IMario>();
            BarrierHandler.RemoveBarrier<IItem>();
        }

        public override bool Solid { get { return !StateController.SpriteState.Exploding; } }

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
