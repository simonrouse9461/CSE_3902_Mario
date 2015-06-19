using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class ColorAnimator
    {
        private Counter Counter;
        private PeriodicFunction<Color> ColorList;

        public ColorAnimator(Color[] colorArray = null, int frequency = 1)
        {
            colorArray = colorArray ?? new[] {Color.White};
            Func<int, Color> colorFunction = i => colorArray[i];
            int period = colorArray.Length;
            ColorList = new PeriodicFunction<Color>(colorFunction, period);
            Counter = new Counter(frequency);
        }

        public void Reset()
        {
            Counter.Reset();
            ColorList.Reset();
        }

        public void Update()
        {
            if (Counter.Update())
            {
                ColorList.Update();
            }
        }

        public Color Color
        {
            get { return ColorList.GetValue(); }
        }
    }
}