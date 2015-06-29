using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : IndestructibleBlockObject
    {

        public HiddenBlockObject() {

            SpriteState = new BlockSpriteState();
            SpriteState.HiddenBlock();
            MotionState = new BlockMotionState();
            CollisionHandler = new BlockCollisionHandler(State);
        
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
