using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public interface ICommandExecutor
    {
        void Reset();
        void ReadCommand(ICommand command);
        void Execute();
    }
}