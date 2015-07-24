namespace SuperMario
{
    public class DefaultBarrierHandler<TStateController> : BarrierHandlerKernel<TStateController>
        where TStateController : IStateController, new()
    {
        public DefaultBarrierHandler(ICore core) : base(core) { }

        public override void HandleCollision() { }
    }
}