using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class State<TS, TM>
        where TS : ISpriteState
        where TM : IMotionState
    {
        private Collection<KeyValuePair<Action<State<TS, TM>>, Counter>> reservations;

        public IObject Object { get; set; }
        public TS SpriteState { get; set; }
        public TM MotionState { get; set; }
        public BarrierDetector BarrierDetector { get; set; }

        public State()
        {
            reservations = new Collection<KeyValuePair<Action<State<TS, TM>>, Counter>>();
        }

        public void DelayCommand(Action<State<TS, TM>> command, int delay = 1)
        {
            reservations.Add(new KeyValuePair<Action<State<TS, TM>>, Counter>(command, new Counter(delay)));
        }

        public void Update()
        {
            for (int i = 0; i < reservations.Count; i++)
            {
                var reservation = reservations[i];
                if (reservation.Value.Update())
                {
                    reservation.Key(this);
                    reservations.Remove(reservation);
                }
            }
        }
    }
}