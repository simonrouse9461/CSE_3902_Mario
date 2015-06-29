using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NormalBlockObject : ObjectKernel<NormalBlockSpriteState, NormalBlockMotionState>
    {
        public NormalBlockObject() {
            SpriteState = new NormalBlockSpriteState();
            MotionState = new NormalBlockMotionState();
            CollisionHandler = new NormalBlockCollisionHandler(Core);
        
        }


        //public void NormalBlockDestroyed()
        //{
        //    SpriteState.Status = NormalBlockSpriteState.StatusEnum.Destroyed;
            
        //}

        //public void NormalBlockUsed()
        //{
        //    SpriteState.Status = NormalBlockSpriteState.StatusEnum.UsedBlock;
        //}

        //public void NormalBlockReset()
        //{
        //    SpriteState.Status = NormalBlockSpriteState.StatusEnum.Normal;
        //}

        protected override void SyncState()
        {

        }
    }
}
