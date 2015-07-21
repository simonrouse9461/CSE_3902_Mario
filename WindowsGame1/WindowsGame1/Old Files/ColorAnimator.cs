using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class ColorAnimator
    {
        private PeriodicFunction<Color> ColorList;

        public ColorAnimator(Color[] colorArray = null)
        {
            colorArray = colorArray ?? new[] {Color.White};
            Func<int, Color> colorFunction = i => colorArray[i];
            int period = colorArray.Length;
            ColorList = new PeriodicFunction<Color>(colorFunction, period);
        }

        public void Reset()
        {
            ColorList.Reset();
        }

        public void Update()
        {
            ColorList.Update();
        }

        public Color Color
        {
            get { return ColorList.Value; }
        }
    }
}