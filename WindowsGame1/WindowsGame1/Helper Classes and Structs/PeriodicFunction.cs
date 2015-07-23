using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class PeriodicFunction<T>
    {
        private Counter Circulator;

        private Func<int, T> Function;

        public int Cycle { get; private set; }

        public PeriodicFunction(Func<int, T> getValue = null, int period = 0)
        { 
            Function = getValue ?? (stage => default(T));
            Circulator = new Counter(period);
        }

        public virtual void Reset()
        {
            Circulator.Reset();
            Cycle = 0;
        }

        public bool Update(int phase = -1)
        {
            if (!Circulator.Update(phase)) return false;
            Cycle ++;
            return true;
        }

        public T Value
        {
            get { return Function(Circulator.Phase); }
        }
    }
}