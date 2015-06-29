using System;

namespace WindowsGame1
{
    public interface IState
    {
        IObject Object { get; set; }
        ISpriteState GeneralSpriteState { get; }
        IMotionState GeneralMotionState { get; }
        BarrierDetector BarrierDetector { get; set; }
        ICollisionHandler CollisionHandler { get; set; }
        ICommandExecutor CommandExecutor { get; set; }

        void DelayCommand(Action command, int delay = 1);
        void DelayCommand(Action command, Func<bool> dependency, int delay = 1);
        void ClearDelayedCommands();
        void Update();
    }
}