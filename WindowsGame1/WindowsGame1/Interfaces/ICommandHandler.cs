using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public interface ICommandHandler<TSpriteState, TMotionState>
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState 
    {
        void Reset();
        void ReadCommand(ICommand command);
        void Handle();
    }
}