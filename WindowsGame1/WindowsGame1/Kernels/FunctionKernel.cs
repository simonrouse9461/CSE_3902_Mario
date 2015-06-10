using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class FunctionKernel<T> : IFunction<T>
    {
        private Counter Stage;

        private Func<int, T> Function;

        protected FunctionKernel(Func<int, T> getValue = null, int period = 0)
        {
            Function = getValue ?? (stage => default(T));
            Stage = new Counter(period);
            Reset();
        }

        public void Reset(int period = -1)
        {
            Stage.Reset(period); 
        }

        public void Update(int phase = 0)
        {
            Stage.Update(phase);
        }

        public T GetValue()
        {
            return Function(Stage.Phase);
        }
    }
}