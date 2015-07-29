using SuperMario;

namespace SuperMario
{
    public class BlockDebris : ObjectKernel<BlockDebrisStateController>
    {
        public BlockDebris()
        {
            BarrierHandler.BecomeNonBarrier();
        }

        public bool Lethal { get; set; }

        public static BlockDebris UpperLeft
        {
            get
            {
                var instance = new BlockDebris();
                instance.StateController.UpperLeft();
                return instance;
            }
        }

        public static BlockDebris UpperRight
        {
            get
            {
                var instance = new BlockDebris();
                instance.StateController.UpperRight();
                return instance;
            }
        }

        public static BlockDebris LowerLeft
        {
            get
            {
                var instance = new BlockDebris();
                instance.StateController.LowerLeft();
                return instance;
            }
        }

        public static BlockDebris LowerRight
        {
            get
            {
                var instance = new BlockDebris();
                instance.StateController.LowerRight();
                return instance;
            }
        }
    }
}