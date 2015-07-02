namespace WindowsGame1
{
    public class MarioStateController : StateControllerKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioStateController(Core<MarioSpriteState, MarioMotionState> core) : base(core) { }

        private bool alreadyShot;

        public override void SyncState()
        {
            if (Core.SpriteState.Dead)
                Core.MotionState.DeadFall();
            if (Core.SpriteState.Shooting && !alreadyShot)
            {
                //alreadyShot = true;
            }
            else
            {
                alreadyShot = false;
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
        }
    }
}