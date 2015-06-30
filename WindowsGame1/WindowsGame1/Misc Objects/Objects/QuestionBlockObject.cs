using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class QuestionBlockObject : IndestructibleBlockObject
    {
        public QuestionBlockObject()
        {
            SpriteState = new BlockSpriteState();
            MotionState = new BlockMotionState();
            
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        protected override void SyncState()
        {

        }
    }
}
