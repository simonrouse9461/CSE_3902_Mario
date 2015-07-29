using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FireExplosionStateController : StateControllerKernel<FireExplosionSpriteState, StaticMotionState>
    {
        public void ToBoth()
        {
            SpriteState.SetSize(ExplosionSize.Large);
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.SpriteAnimation, () => Core.Object.Unload(true));
            Core.DelayCommand(
                () =>
                    Core.Object.Generate(new Vector2(-(int) SpriteState.Size, 0)*5*GameSettings.SpriteScale,
                        FireExplosion.LeftSide((ExplosionSize)(int) SpriteState.Size - 1)), 5);
            Core.DelayCommand(
                () =>
                    Core.Object.Generate(new Vector2((int) SpriteState.Size, 0)*5*GameSettings.SpriteScale,
                        FireExplosion.RightSide((ExplosionSize)(int) SpriteState.Size - 1)), 5);
            Core.DelayCommand(
                () =>
                    Core.Object.Generate(new Vector2(-(int) SpriteState.Size, 0)*GameSettings.SpriteScale,
                        FireExplosion.LeftSide((ExplosionSize)(int)SpriteState.Size - 1)), 10);
            Core.DelayCommand(
                () =>
                    Core.Object.Generate(new Vector2((int) SpriteState.Size, 0)*GameSettings.SpriteScale,
                        FireExplosion.RightSide((ExplosionSize)(int)SpriteState.Size - 1)), 10);
        }

        public void ToLeft(ExplosionSize size)
        {
            SpriteState.SetSize(size);
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.SpriteAnimation, () => Core.Object.Unload(true));
            if (SpriteState.Size != ExplosionSize.Tiny)
                Core.DelayCommand(
                    () =>
                        Core.Object.Generate(new Vector2(-(int) SpriteState.Size, 0)*5*GameSettings.SpriteScale,
                            FireExplosion.LeftSide((ExplosionSize)(int)SpriteState.Size - 1)), 5);
        }

        public void ToRight(ExplosionSize size)
        {
            SpriteState.SetSize(size);
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.SpriteAnimation, () => Core.Object.Unload(true));
            if (SpriteState.Size != ExplosionSize.Tiny)
                Core.DelayCommand(
                    () =>
                        Core.Object.Generate(new Vector2((int) SpriteState.Size, 0)*5*GameSettings.SpriteScale,
                            FireExplosion.RightSide((ExplosionSize)(int)SpriteState.Size - 1)), 5);
        }

        public void Single(ExplosionSize size)
        {
            SpriteState.SetSize(size);
            SpriteState.HoldTillFinish(true, SpriteHoldDependency.SpriteAnimation, () => Core.Object.Unload(true));
        }
    }
}
