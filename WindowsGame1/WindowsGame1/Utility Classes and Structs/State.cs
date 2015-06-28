using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class State<TS, TM>
        where TS : ISpriteState
        where TM : IMotionState
    {
        private class Reservation
        {
            public Action<State<TS, TM>> Command { get; set; }
            public Func<State<TS, TM>, bool> Dependency { get; set; }
            public Counter Timer { get; set; }
        }

        private Collection<Reservation> Waitlist;

        public IObject Object { get; set; }
        public TS SpriteState { get; set; }
        public TM MotionState { get; set; }
        public BarrierDetector BarrierDetector { get; set; }

        public State()
        {
            Waitlist = new Collection<Reservation>();
        }

        public void DelayCommand(Action<State<TS, TM>> command, Func<State<TS, TM>, bool> dependency = null, int delay = 1)
        {
            if (dependency == null)
                dependency = condition => true;
            Waitlist.Add(new Reservation
            {
                Command = command,
                Dependency = dependency,
                Timer = new Counter(delay)
            });
        }

        public void ClearDelayedCommands()
        {
            Waitlist = new Collection<Reservation>();
        }

        public void Update()
        {
            for (var i = 0; i < Waitlist.Count; i++)
            {
                var reservation = Waitlist[i];
                if (!reservation.Dependency(this))
                {
                    Waitlist.Remove(reservation);
                }
                if (reservation.Timer.Update())
                {
                    reservation.Command(this);
                    Waitlist.Remove(reservation);
                }
            }
        }
    }
}