namespace SuperMario
{
    public class StaticSpriteState<TSprite> : SpriteStateKernel<int>
        where TSprite : ISprite, new()
    {
        public StaticSpriteState()
        {
            AddSprite<TSprite>();
            SetSprite<TSprite>();
        } 
    }
}