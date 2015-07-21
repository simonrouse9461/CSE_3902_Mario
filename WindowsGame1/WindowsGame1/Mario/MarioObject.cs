namespace WindowsGame1
{
    public class MarioObject : ObjectKernelNew<MarioStateController>, IMario
    {
        public MarioObject()
        {
            CommandExecutor = new MarioCommandExecutor(Core);
            CollisionHandler = new MarioCollisionHandler(Core);
            BarrierHandler = new MarioBarrierHandler(Core);

            StateController.SpriteState.TurnSmall();
            BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<FireballObject>();
            BarrierHandler.RemoveBarrier<IItem>();
            BarrierHandler.RemoveBarrier<IEnemy>();
            SoundManager.changeToOverworldMusic();
        }

        public override bool Solid
        {
            get { return Alive; }
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
    }
}