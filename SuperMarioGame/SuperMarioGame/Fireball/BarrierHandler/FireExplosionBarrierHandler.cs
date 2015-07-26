namespace SuperMario
{
    public class FireExplosionBarrierHandler : BarrierHandlerKernelNew<FireExplosionStateController>
    {
        public FireExplosionBarrierHandler(ICoreNew core) : base(core) { }

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