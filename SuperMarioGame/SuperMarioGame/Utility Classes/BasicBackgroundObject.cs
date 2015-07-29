namespace SuperMario
{
    public class BasicBackgroundObject<TSprite> : BackgroundObjectKernel<StaticSpriteState<TSprite>>
        where TSprite : ISprite, new() { }
}