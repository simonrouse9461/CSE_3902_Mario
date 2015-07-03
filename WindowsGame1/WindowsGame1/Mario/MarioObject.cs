namespace WindowsGame1
{
    public class MarioObject : ObjectKernel<MarioSpriteState, MarioMotionState>, IMario
    {
        public MarioObject()
        {
            CommandExecutor = new MarioCommandExecutor(Core);
            CollisionHandler = new MarioCollisionHandler(Core);
            BarrierDetector = new MarioBarrierDetector(Core);
            StateController = new MarioStateController(Core);
            SpriteState.BecomeSmall();
            BarrierDetector.AddBarrier<IObject>();
        }

        public override bool Solid
        {
            get { return Alive; }
        }

        public bool Alive
        {
            get { return !SpriteState.Dead; }
        }

        public bool StarPower
        {
            get { return SpriteState.HaveStarPower; }
        }

        public bool Destructive
        {
            get { return !SpriteState.Small; }
        }
    }
}