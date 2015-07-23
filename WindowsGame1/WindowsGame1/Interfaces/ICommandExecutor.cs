using System;
using System.Collections.Generic;

namespace SuperMario
{
    public interface ICommandExecutor
    {
        void Reset();
        void ReadCommand(ICommand command);
        void Execute();
    }
}