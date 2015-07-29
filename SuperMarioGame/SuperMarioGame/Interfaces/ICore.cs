using System;

namespace SuperMario
{
    public interface ICore
    {
        IObject Object { get; set; }
        IStateController GeneralStateController { get; }
        ISpriteState GeneralSpriteState { get; }
        IMotionState GeneralMotionState { get; }
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