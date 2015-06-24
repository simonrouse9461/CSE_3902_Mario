using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : ObjectKernelNew<HiddenBlockSpriteState, HiddenBlockMotionState>
    {

        public HiddenBlockObject(WorldManager world) : base(world) { 
        
            SpriteState = new HiddenBlockSpriteState();
            MotionState = new HiddenBlockMotionState();
            CollisionHandler = new HiddenBlockCollisionHandler(State);
        
        }

        //public void HiddenBlocktoUsed()
        //{
        //    SpriteState.Status = HiddenBlockSpriteState.StatusEnum.UsedBlock;
        //}

        //public void HiddenBlockReset()
        //{
        //    SpriteState.Status = HiddenBlockSpriteState.StatusEnum.Hidden;
        //}

        protected override void SyncState()
        {

        }
    }

}
