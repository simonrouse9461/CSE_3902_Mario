using MarioGame;

namespace MarioGame
{
    public class BlockDebrisObject : ObjectKernelNew<BlockDebrisStateController>
    {
        public BlockDebrisObject()
        {
            
        }

        public override bool Solid { get { return false; } }

        public static BlockDebrisObject UpperLeft
        {
            get
            {
                var instance = new BlockDebrisObject();
                instance.StateController.UpperLeft();
                return instance;
            }
        }

        public static BlockDebrisObject UpperRight
        {
            get
            {
                var instance = new BlockDebrisObject();
                instance.StateController.UpperRight();
                return instance;
            }
        }

        public static BlockDebrisObject LowerLeft
        {
            get
            {
                var instance = new BlockDebrisObject();
                instance.StateController.LowerLeft();
                return instance;
            }
        }

        public static BlockDebrisObject LowerRight
        {
            get
            {
                var instance = new BlockDebrisObject();
                instance.StateController.LowerRight();
                return instance;
            }
        }
    }
}