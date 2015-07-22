using System;

namespace MarioGame
{
    public class FinishLevelBarrierHandler : MarioBarrierHandler, IDecorator
    {
        public MarioBarrierHandler DefaultBarrierHandler { get; private set; }
        public FinishLevelBarrierHandler(ICoreNew core) : base(core)
        {
            DefaultBarrierHandler = (MarioBarrierHandler)core.BarrierHandler;
            AddBarrier<IObject>();
        }

        public void Restore()
        {
            Core.SwitchComponent(DefaultBarrierHandler);
        }

        public void DelayRestore(int timeDelay)
        {
            Core.DelayCommand(Restore, () => Core.BarrierHandler is FinishLevelBarrierHandler, timeDelay);
        }

        protected override void CheckFloor()
        {
            if (BarrierCollision.Bottom.Touch)
            {
                RemoveBarrier<FlagPoleObject>();
                Core.StateController.KeepOnLand();
                Core.StateController.KeepRight();
            }
            else { Core.StateController.Liftoff(); }
        }
    }
}