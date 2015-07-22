using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class FlagPoleObject : ObjectKernelNew<FlagStateController>
    {
        public FlagPoleObject()
        {
            StateController.Flag();
        }

        public override Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(
                    PositionRectangle.X + 4, 
                    PositionRectangle.Y, 
                    PositionRectangle.Width - 8,
                    PositionRectangle.Height);
            }
        }
    }
}
