namespace SuperMario
{
    public class Mario : ObjectKernel<MarioStateController>, IMario
    {
        public Mario()
        {
            CommandExecutor = new MarioCommandExecutor(Core);
            CollisionHandler = new MarioCollisionHandler(Core);
            BarrierHandler = new MarioBarrierHandler(Core);

            StateController.SpriteState.TurnSmall();
            BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<IFireball>();
            BarrierHandler.RemoveBarrier<IItem>();
            BarrierHandler.RemoveBarrier<IEnemy>();

            SoundManager.SwitchToOverworldMusic();
        }

        public bool Alive
        {
            get { return !StateController.SpriteState.Dead; }
        }

        public bool StarPower
        {
            get { return StateController.SpriteState.HavePower; }
        }

        public bool Destructive
        {
            get { return !StateController.SpriteState.Small; }
        }

        public void Freeze()
        {
            StateController.MotionState.Freeze();
        }
    }
}