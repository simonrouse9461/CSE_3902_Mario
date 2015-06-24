using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockCollisionHandler : CollisionHandlerKernelNew<NormalBlockSpriteState, NormalBlockMotionState>
    {
        
        public NormalBlockCollisionHandler(State<NormalBlockSpriteState, NormalBlockMotionState> state) : base(state) {
            AddBarrier<IObject>();
        }

        public override void Handle(){
            if(Detector.Detect<MarioObject>().Bottom.Contact){
                State.Object.Unload();
            }
        }
    }
}
