using Microsoft.Xna.Framework;

namespace SuperMario
{
    public  class Koopa : EnemyKernel<KoopaStateController>
    {
        public bool IsMovingShell
        {
            get { return StateController.SpriteState.Dead && StateController.MotionState.IsMovingShell; }
        }

        public override Rectangle CollisionRectangle
        {
            get
            {
                return PositionRectangle.Height <= GameSettings.ScaledGridLength
                    ? PositionRectangle
                    : new Rectangle(PositionRectangle.X,
                        PositionRectangle.Y + (PositionRectangle.Height - GameSettings.ScaledGridLength),
                        PositionRectangle.Width, GameSettings.ScaledGridLength);
            }
        }
    }
}
