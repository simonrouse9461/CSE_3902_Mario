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
                    Core.StateController.SpriteState.Reset();
                    Core.StateController.SpriteState.Freeze();
                    Core.DelayCommand(SoundManager.ChangeToWinMusic, 20);
                    Core.DelayCommand(() => Core.StateController.Flip(WorldManager.FindObject<FlagPoleObject>().PositionPoint.X + 0.5f), 40);
                    Core.DelayCommand(() =>
                    {
                        Core.StateController.KeepRight();
                        Core.StateController.SpriteState.Release();
                        Core.StateController.SpriteState.Resume();
                    }, 80);
                }
                Core.StateController.KeepOnLand();
            }
            else { Core.StateController.Liftoff(); }
        }
    }
}