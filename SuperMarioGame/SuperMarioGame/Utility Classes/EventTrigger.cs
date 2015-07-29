using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class EventTrigger : IEventTrigger
    {
        private ICore Core { get; set; }

        private OrderedPairs<Func<bool>, Action> EventList { get; set; }

        public EventTrigger(ICore core)
        {
            Core = core;
            EventList = new OrderedPairs<Func<bool>, Action>();
        }

        public void AddAbsoluteLocationEvent(int xLocation, Action action, Func<bool> dependency = null)
        {
            dependency = dependency ?? (() => true);
             var condition = Core.Object.PositionPoint.X < xLocation
                ? (Func<bool>)(() => Core.Object.PositionPoint.X >= xLocation && dependency())
                : (() => Core.Object.PositionPoint.X <= xLocation && dependency());
            EventList.Add(condition, action);
        }

        public void AddRelativeLocationEvent(int distance, Action action, Func<bool> dependency = null)
        {
            AddAbsoluteLocationEvent((int)Core.Object.PositionPoint.X + distance, action, dependency);   
        }

        public void AddAreaEvent(Rectangle area, Action action, Func<bool> dependency = null)
        {
            //TODO
        }

        public void AddAbsoluteTimeEvent(int time, Action action, Func<bool> dependency = null)
        {
            //TODO
        }

        public void AddRelativeTimeEvent(int time, Action action, Func<bool> dependency = null)
        {
            //TODO
        }

        public void CheckEvent()
        {
            for (var i = 0; i < EventList.Count; i++)
            {
                if (EventList.KeyAt(i)())
                {
                    EventList.ValueAt(i)();
                    EventList.Remove(EventList.KeyAt(i));
                    i--;
                }
            }
        }
    }
}