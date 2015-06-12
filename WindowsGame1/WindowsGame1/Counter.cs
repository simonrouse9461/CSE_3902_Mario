using System;
using System.Resources;

namespace WindowsGame1
{
    public class Counter
    {
        private int _cycle;

        public int Cycle
        {
            get { return _cycle; }
            set
            {
                _cycle = value;
                Phase = 0;
            }
        }

        private int _phase;

        public int Phase
        {
            get { return _phase; }
            set
            {
                _phase = value;
                if (_phase == Cycle || _phase == Int64.MaxValue)
                    _phase = 0;
            }
        }

        public Counter(int cycle = 1)
        {
            Reset(cycle);
        }

        public void Reset(int cycle = -1)
        {
            if (cycle != -1)
                Cycle = cycle;
            Phase = 0;
        }

        public bool Update(int phase = 0)
        {
            if (phase == 0)
                Phase++;
            else
                Phase = phase;
            return Phase == 0;
        }

    }
}