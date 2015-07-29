namespace SuperMario
{
    public class DefaultBarrierHandler : AbstractBarrierHandlerKernel<IStateController>
    {
        public DefaultBarrierHandler(ICore core) : base(core) { }

        public override void HandleCollision() { }
    }
}