using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface IEventTrigger
    {
        void AddAbsoluteLocationEvent(int xLocation, Action action, Func<bool> dependency = null);
        void AddRelativeLocationEvent(int distance, Action action, Func<bool> dependency = null);
        void AddAreaEvent(Rectangle area, Action action, Func<bool> dependency = null);
        void AddAbsoluteTimeEvent(int time, Action action, Func<bool> dependency = null);
        void AddRelativeTimeEvent(int time, Action action, Func<bool> dependency = null);
        void CheckEvent();
    }
}