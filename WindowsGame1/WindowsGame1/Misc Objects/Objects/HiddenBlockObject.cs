using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : IndestructibleBlockObject
    {

        public HiddenBlockObject()
        {
            SpriteState.HiddenBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        //public void HiddenBlocktoUsed()
        //{
        //    SpriteState.Status = HiddenBlockSpriteState.StatusEnum.UsedBlock;
        //}

        //public void HiddenBlockReset()
        //{
        //    SpriteState.Status = HiddenBlockSpriteState.StatusEnum.Hidden;
        //}
    }
}
