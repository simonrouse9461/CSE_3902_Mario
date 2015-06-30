using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : IndestructibleBlockObject
    {

        public HiddenBlockObject() {
            SpriteState.HiddenBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        
        }
        protected override void SyncState()
        {

        }
    }

}
