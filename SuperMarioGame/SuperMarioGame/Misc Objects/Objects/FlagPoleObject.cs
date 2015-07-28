using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FlagPoleObject : ObjectKernelNew<FlagPoleStateController>
    {
        public FlagPoleObject()
        {
            StateController.FlagPole();
        }

        public override Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(
                    (int)(PositionRectangle.X + 3*GameSettings.SpriteScale), 
                    PositionRectangle.Y, 
                    (int)(PositionRectangle.Width - 6*GameSettings.SpriteScale),
                    PositionRectangle.Height);
            }
        }
    }
}
