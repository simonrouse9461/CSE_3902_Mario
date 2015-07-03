namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        private CollisionDetector Detector;
        private bool alreadyShot;

        public MarioStateController(Core<MarioSpriteState, MarioMotionState> core) : base(core)
        {
            Detector = new CollisionDetector(Core.Object);
        }

        private void CheckMotion()
        {
            if (Detector.Detect<IObject>(obj => obj.Solid).Bottom.Touch)
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
                Core.SpriteState.Jump();
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