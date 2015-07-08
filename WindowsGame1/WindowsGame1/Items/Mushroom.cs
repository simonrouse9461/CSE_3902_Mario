using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernelNew<MushroomStateController>, IItem
    {
        public Mushroom()
        {
            CollisionHandler = new ItemCollisionHandler(Core);
            BarrierDetector = new MarioBarrierDetector(Core);
            BarrierDetector.AddBarrier<IBlock>();
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return true; }
        }
    }
}
