namespace SuperMario
{
    public class FireExplosionBarrierHandler : BarrierHandlerKernel<FireExplosionStateController>
    {
        public FireExplosionBarrierHandler(ICore core) : base(core) { }

        public override void HandleCollision()
        {
            HitWall();
        }

        private void HitWall()
        {
            if (BarrierCollision.AnySide.Touch)
            {
                //TODO
            }
        }
    }
}