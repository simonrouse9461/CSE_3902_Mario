using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class PeriodicFunction<T>
    {
        private Counter Circulator;

        private Func<int, T> Function;

        public PeriodicFunction(Func<int, T> getValue = null, int period = 0)
        { 
            Function = getValue ?? (stage => default(T));
            Circulator = new Counter(period);
        }

        public virtual void Reset()
        {
            Circulator.Reset(); 
        }

        public void Update(int phase = -1)
        {
            Circulator.Update(phase);
        }

        public T Value
        {
            get { return Function(Circulator.Phase); }
        }
    }
}