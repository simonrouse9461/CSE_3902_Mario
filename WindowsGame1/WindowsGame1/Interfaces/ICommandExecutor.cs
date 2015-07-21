using System;
using System.Collections.Generic;

namespace MarioGame
{
    public interface ICommandExecutor
    {
        void Reset();
        void ReadCommand(ICommand command);
        void Execute();
    }
}