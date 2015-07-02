namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioStateController(Core<MarioSpriteState, MarioMotionState> core) : base(core) { }

        private bool alreadyShot;

        private void CheckMotion()
        {
            if (Core.MotionState.VerticalStatic)
            {
                if (Core.MotionState.HorizontalStatic)
                {
                    Core.SpriteState.Stand();
                }
                else
                {
                    if (Core.MotionState.MovingRight == Core.SpriteState.Right)
                        Core.SpriteState.Run();
                    else
                        Core.SpriteState.Turn();
                }
            }
            else
            {
                if (Core.MotionState.Raising)
                    Core.SpriteState.Jump();
                else if (Core.MotionState.Falling)
                    Core.SpriteState.Crouch();
            }
        }

        private bool CheckDead()
        {
            if (Core.SpriteState.Dead)
            {
                Core.MotionState.DeadFall();
                return true;
            }
            return false;
        }

        private bool CheckShoot()
        {
            return Core.SpriteState.Shooting && !alreadyShot;
        }

        public override void SyncState()
        {
            if (!CheckDead())
            {
                if (!CheckShoot())
                    CheckMotion();
            }
        }

        public override void Update()
        {
            if (CheckShoot())
            {
                Core.DelayCommand(() => alreadyShot = true, 8);
            }
            if (!Core.SpriteState.Shooting && alreadyShot)
            {
                alreadyShot = false;
            }
        }
    }
}