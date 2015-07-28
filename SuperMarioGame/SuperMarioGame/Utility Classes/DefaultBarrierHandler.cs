namespace SuperMario
{
    public class DefaultBarrierHandler : AbstractBarrierHandlerKernel<IStateControllerNew>
    {
        public DefaultBarrierHandler(ICoreNew core) : base(core) { }

        public override void HandleCollision() { }
    }
}