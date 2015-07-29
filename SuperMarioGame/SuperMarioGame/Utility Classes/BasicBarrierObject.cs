namespace SuperMario
{
    public class BasicBarrierObject<TSprite> : BasicBackgroundObject<TSprite>
        where TSprite : ISprite, new()
    {
        public override bool IsBarrier { get { return true; } }
    }
}