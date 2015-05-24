using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{

    public class DeadMovingUpAndDownMarioSprite : ISprite
    {
        // Kernal sprite information
        private static Texture2D Texture;
        private static Vector2 StartCoordinate = new Vector2(0, 16);
        private static Vector2 EndCoordinate = new Vector2(14, 29);
        private static int TotalFrames = 1;

        // Computed sprite information
        private static int Width = (int)(EndCoordinate.X - StartCoordinate.X) / TotalFrames;
        private static int Height = (int)(EndCoordinate.Y - StartCoordinate.Y);

        // Animation information
        private static int Period = 8;
        private static Vector2 TotalDisplacement = new Vector2(0, 20);
        private static int NumOfDisplacement = 5;
        private static int[] FrameSequence = {0, 0, 0, 0, 0, 0, 0, 0};
        private static int[] DisplacementSequence = { 0, 1, 2, 3, 4, 3, 2, 1 };
        private int _TimeInterval;
        public int TimeInterval
        {
            get { return _TimeInterval; }
            set
            {
                _TimeInterval = value;
                DelayPhase = 0;
            }
        }
        private Vector2 GetDisplacement()
        {
            return CurrentDisplacement * TotalDisplacement / NumOfDisplacement;
        }

        // State information
        public int DelayPhase { get; set; }
        public int PeriodPhase { get; set; }
        private int CurrentFrame;
        private int CurrentDisplacement;

        // Constructor
        public DeadMovingUpAndDownMarioSprite()
        {
            TimeInterval = 10;
            DelayPhase = 0;
            PeriodPhase = 0;
            CurrentDisplacement = DisplacementSequence[PeriodPhase];
        }

        public void Load(ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("mario");
        }
        public void Reset()
        {
            DelayPhase = 0;
            PeriodPhase = 0;
            CurrentFrame = FrameSequence[PeriodPhase];
            CurrentDisplacement = DisplacementSequence[PeriodPhase];
        }

        public void Update()
        {
            DelayPhase++;
            if (DelayPhase >= TimeInterval)
            {
                DelayPhase = 0;
                PeriodPhase++;
                if (PeriodPhase >= Period)
                {
                    PeriodPhase = 0;
                }
                CurrentFrame = FrameSequence[PeriodPhase];
                CurrentDisplacement = DisplacementSequence[PeriodPhase];
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location += GetDisplacement();
            Rectangle sourceRectangle = new Rectangle((int)StartCoordinate.X + Width*CurrentFrame, (int)StartCoordinate.Y,
                Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}