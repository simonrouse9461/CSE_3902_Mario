using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockObject : BlockKernel
    {
        public DestructibleBlockObject() {
            SpriteState.DestructibleBlock();
            CollisionHandler = new BlockCollisionHandler(Core); 
        }
    }
}
