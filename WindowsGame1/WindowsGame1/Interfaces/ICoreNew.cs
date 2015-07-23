using System;

namespace MarioGame
{
    public interface ICoreNew
    {
        IObject Object { get; set; }
        IStateControllerNew GeneralStateController { get; }
        ISpriteStateNew GeneralSpriteState { get; }
        IMotionStateNew GeneralMotionState { get; }
        CollisionDetector CollisionDetector { get; set; }
        IBarrierHandler BarrierHandler { get; set; }
        ICollisionHandler CollisionHandler { get; set; }
        ICommandExecutor CommandExecutor { get; set; }
        IEventTrigger EventTrigger { get; set; }

        void DelayCommand(Action command, int delay = 1);
        void DelayCommand(Action command, Func<bool> dependency, int delay = 1);
        void ClearDelayedCommands();
        void SwitchComponent(object component);
        void Update();
    }
}