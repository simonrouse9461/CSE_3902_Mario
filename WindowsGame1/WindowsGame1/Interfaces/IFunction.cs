using System;

namespace WindowsGame1
{
    public interface IFunction<T>
    {
        void Initialize();
        void Reset(int period = -1);
        void Update(int stage = 0);
        T GetValue();
    }
}