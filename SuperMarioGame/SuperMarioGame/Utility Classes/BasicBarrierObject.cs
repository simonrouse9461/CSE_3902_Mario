namespace SuperMario
{
    public class BasicBarrierObject<TSprite> : BasicBackgroundObject<TSprite>
        where TSprite : ISpriteNew, new()
    {
        public override bool IsBarrier { get { return true; } }
    }
}