using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class FunctionKernel<T> : IFunction<T>
    {
        protected Counter Stage;

        protected Func<int, T> Function;

        protected FunctionKernel(Func<int, T> getValue = null, int period = 0)
        {
            Function = getValue ?? (stage => default(T));
            Stage = new Counter(period);
            Initialize();
            Reset();
        }

        public abstract void Initialize();

        public void Reset(int period = -1)
        {
            Stage.Reset(period); 
        }

        public void Update(int stage = 0)
        {
            Stage.Update(stage);
        }

        public T GetValue()
        {
            return Function(Stage.Phase);
        }
    }
}