using System;
using System.Collections.ObjectModel;

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
    }
}