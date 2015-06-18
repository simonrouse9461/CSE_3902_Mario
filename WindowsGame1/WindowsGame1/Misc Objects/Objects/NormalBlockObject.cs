using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NormalBlockObject : ObjectKernel<NormalBlockSpriteState, NormalBlockMotionState>
    {
        public NormalBlockObject(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new NormalBlockSpriteState();
            MotionState = new NormalBlockMotionState();
            CollisionHandler = new NormalBlockCollisionHandler(SpriteState, MotionState, this);
        }

        public void NormalBlockDestroyed()
        {
            SpriteState.Status = NormalBlockSpriteState.StatusEnum.Destroyed;
            
        }

        public void NormalBlockUsed()
        {
            SpriteState.Status = NormalBlockSpriteState.StatusEnum.UsedBlock;
        }

        public void NormalBlockReset()
        {
            SpriteState.Status = NormalBlockSpriteState.StatusEnum.Normal;
        }

        protected override void SyncState()
        {

        }
    }
}
