using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class PeriodicFunction<T> : IPeriodicFunction<T>
    {
        private Counter Circulator;

        private Func<int, T> Function;

        public PeriodicFunction(Func<int, T> getValue = null, int period = 0)
        {
            Function = getValue ?? (stage => default(T));
            Circulator = new Counter(period);
            Reset();
        }

        public void Reset(int period = -1)
        {
            Circulator.Reset(period); 
        }

        public void Update(int phase = 0)
        {
            Circulator.Update(phase);
        }

        public T GetValue()
        {
            return Function(Circulator.Phase);
        }
    }
}