using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioObject : ObjectKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new MarioSpriteState();
            MotionState = new MarioMotionState(location);
        }

        public void FaceLeft()
        {
            SpriteState.Orientation = MarioSpriteState.OrientationEnum.Left;
        }

        public bool IsLeft()
        {
            return SpriteState.Orientation == MarioSpriteState.OrientationEnum.Left;
        }

        public void FaceRight()
        {
            SpriteState.Orientation = MarioSpriteState.OrientationEnum.Right;
        }

        public bool IsRight()
        {
            return SpriteState.Orientation == MarioSpriteState.OrientationEnum.Right;
        }

        public void BecomeBig()
        {
            SpriteState.Status = MarioSpriteState.StatusEnum.Big;
        }

        public bool IsBig()
        {
            return SpriteState.Status == MarioSpriteState.StatusEnum.Big;
        }

        public void BecomeSmall()
        {
            SpriteState.Status = MarioSpriteState.StatusEnum.Small;
        }

        public bool IsSmall()
        {
            return SpriteState.Status == MarioSpriteState.StatusEnum.Small;
        }

        public void BecomeDead()
        {
            SpriteState.Status = MarioSpriteState.StatusEnum.Dead;
        }

        public bool IsDead()
        {
            return SpriteState.Status == MarioSpriteState.StatusEnum.Dead;
        }

        public void BecomeFire()
        {
            SpriteState.Status = MarioSpriteState.StatusEnum.Fire;
        }

        public bool IsFire()
        {
            return SpriteState.Status == MarioSpriteState.StatusEnum.Fire;
        }

        public void Run()
        {
            SpriteState.Action = MarioSpriteState.ActionEnum.Run;
        }

        public bool IsRun()
        {
            return SpriteState.Action == MarioSpriteState.ActionEnum.Run;
        }

        public void Jump()
        {
            SpriteState.Action = MarioSpriteState.ActionEnum.Jump;
        }

        public bool IsJump()
        {
            return SpriteState.Action == MarioSpriteState.ActionEnum.Jump;
        }

        public void Crouch()
        {
            SpriteState.Action = MarioSpriteState.ActionEnum.Crouch;
        }

        public bool IsCrouch()
        {
            return SpriteState.Action == MarioSpriteState.ActionEnum.Crouch;
        }

        public void Stand()
        {
            SpriteState.Action = MarioSpriteState.ActionEnum.Stand;
        }

        public bool IsStand()
        {
            return SpriteState.Action == MarioSpriteState.ActionEnum.Stand;
        }
    }
}