using System;

namespace MarioGame
{
    public class FinishLevelMarioBarrierHandler : MarioBarrierHandler, IDecorator
    {
        public MarioBarrierHandler DefaultBarrierHandler { get; private set; }
        public FinishLevelMarioBarrierHandler(ICoreNew core) : base(core)
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
            Core.DelayCommand(Restore, () => Core.BarrierHandler is FinishLevelMarioBarrierHandler, timeDelay);
        }

        protected override void CheckFloor()
        {
            if (BarrierCollision.Bottom.Touch)
            {
                if (Core.StateController.MotionState.Sliping)
                {
                    Core.DelayCommand(Core.StateController.Flip, 50);
                    Core.DelayCommand(() =>
                    {
                        Core.StateController.GoRight();
                        Core.StateController.KeepRight();
                        Core.StateController.SpriteState.Release();
                    }, 100);
                }
                Core.StateController.KeepOnLand();
            }
            else { Core.StateController.Liftoff(); }
        }
    }
}