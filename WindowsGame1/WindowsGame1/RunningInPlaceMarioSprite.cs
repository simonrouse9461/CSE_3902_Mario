using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{

    public class RunningInPlaceMarioSprite : ISprite
    {
        // Kernal sprite information
        private static Texture2D Texture;
        private static Vector2 StartCoordinate = new Vector2(230, 50);
        private static Vector2 EndCoordinate = new Vector2(322, 85);
        private static int TotalFrames = 3;

        // Computed sprite information
        private static int Width = (int) (EndCoordinate.X - StartCoordinate.X)/TotalFrames;
        private static int Height = (int) (EndCoordinate.Y - StartCoordinate.Y);

        // Animation information
        private static int Period = 3;
        private static Vector2 TotalDisplacement = new Vector2(0, 0);
        private static int NumOfDisplacement = 1;
        private static int[] FrameSequence = {2, 1, 0};
        private static int[] DisplacementSequence = {0, 0, 0};
        private int _TimeInterval = 10;
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
            return new Vector2(0);
        }

        // State information
        public int DelayPhase { get; set; }
        private int PeriodPhase { get; set; }
        private int CurrentFrame;
        private int CurrentDisplacement;

        // Constructor
        public RunningInPlaceMarioSprite()
        {
            DelayPhase = 0;
            PeriodPhase = 0;
            CurrentFrame = FrameSequence[PeriodPhase];
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
            Rectangle sourceRectangle = new Rectangle((int) StartCoordinate.X + Width*CurrentFrame, (int) StartCoordinate.Y,
                Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
