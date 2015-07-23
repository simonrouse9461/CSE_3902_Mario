namespace SuperMario
{
    public class FireBallBarrierHandler : BarrierHandlerKernelNew<FireballStateController>
    {
        public FireBallBarrierHandler(ICoreNew core) : base(core) { }

        public override void HandleCollision()
        {
            HitWall();
            HitFloor();
        }

        private void HitWall()
        {
            if (BarrierCollision.AnySide.Touch) 
                Core.StateController.Explode();
        }

        private void HitFloor()
        {
            if (BarrierCollision.Bottom.Touch) 
                Core.StateController.Bounce();
        }
    }
}