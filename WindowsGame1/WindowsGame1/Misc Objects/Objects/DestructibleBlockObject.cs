using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockObject : IndestructibleBlockObject
    {

        public DestructibleBlockObject() {
            SpriteState.DestructibleBlock();
            CollisionHandler = new BlockCollisionHandler(Core); 
        }

        protected override void SyncState()
        {
           
        }
    }

}
