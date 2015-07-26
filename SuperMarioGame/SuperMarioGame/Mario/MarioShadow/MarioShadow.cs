namespace SuperMario
{
    public class MarioShadow : BackgroundObjectKernel<MarioShadowSpriteState>
    {
        public MarioShadow() { }

        public MarioShadow(ISpriteNew sprite, Orientation orientation)
        {
            SpriteState.PassSprite(sprite);
            SpriteState.Load(MainGame.ContentManager);
            SpriteState.SetOrientation(orientation);
            SpriteState.Freeze();
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.ColorAnimation, () => Unload(true));
        }
    }
}