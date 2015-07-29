namespace SuperMario
{
    public class MarioShadow : BackgroundObjectKernel<MarioShadowSpriteState>
    {
        public MarioShadow() { }

        public MarioShadow(ISprite sprite, Orientation orientation)
        {
            SpriteState.PassSprite(sprite);
            SpriteState.SetOrientation(orientation);
            SpriteState.Freeze();
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.ColorAnimation, () => Unload(true));
        }
    }
}