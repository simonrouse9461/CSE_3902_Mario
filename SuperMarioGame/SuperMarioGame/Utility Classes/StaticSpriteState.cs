namespace SuperMario
{
    public class StaticSpriteState<TSprite> : SpriteStateKernelNew<int>
        where TSprite : ISpriteNew, new()
    {
        public StaticSpriteState()
        {
            AddSprite<TSprite>();
            SetSprite<TSprite>();
        } 
    }
}