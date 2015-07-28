using System;
using System.Resources;

namespace SuperMario
{
    public class Counter
    {
        private int _frequency;

        public int Frequency
        {
            get { return _frequency; }
            set
            {
                _frequency = value;
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
                if (_phase == Frequency || _phase >= int.MaxValue)
                    _phase = 0;
            }
        }

        public int NextPhase
        {
            get { return _phase + 1 == Frequency ? 0 : _phase + 1; }
        }

        public Counter(int frequency = 1)
        {
            Reset(frequency);
        }

        public void Reset(int frequency = -1)
        {
            if (frequency != -1)
                Frequency = frequency;
            Phase = 0;
        }

        public bool Update(int phase = -1)
        {
            if (phase == -1)
                Phase++;
            else
                Phase = phase;
            return Phase == 0;
        }

    }
}