using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : ObjectKernel<HiddenBlockSpriteState, HiddenBlockMotionState>
    {

        public HiddenBlockObject() { 
        
            SpriteState = new HiddenBlockSpriteState();
            MotionState = new HiddenBlockMotionState();
            CollisionHandler = new HiddenBlockCollisionHandler(Core);
        
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
