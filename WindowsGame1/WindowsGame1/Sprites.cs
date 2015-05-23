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
        // Content manager to load texture
        private static ContentManager Content;

        // Kernal sprite information
        private static Texture2D Texture;
        private static Vector2 StartCoordinate = new Vector2(230, 50);
        private static Vector2 EndCoordinate = new Vector2(322, 85);
        private static int TotalFrames = 3;

        // Other sprite information
        private static int Width = (int) (EndCoordinate.X - StartCoordinate.X)/TotalFrames;
        private static int Height = (int)(EndCoordinate.Y - StartCoordinate.Y);

        // Static animation information
        private static int Period = 3;
        private static int[] FrameSequence = {2, 1, 0};

        // Dynamic animation information
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

        // State information
        public int DelayPhase { get; set; }
        public int PeriodPhase { get; set; }
        private int CurrentFrame;

        // Constructor
        public RunningInPlaceMarioSprite(ContentManager content)
        {
            Content = content;
            TimeInterval = 10;
            DelayPhase = 0;
            PeriodPhase = 0;
            CurrentFrame = FrameSequence[PeriodPhase];
        }

        public void Load()
        {
            Texture = Content.Load<Texture2D>("mario");
        }

        public void Update()
        {
            DelayPhase++;
            if (DelayPhase == TimeInterval)
            {
                DelayPhase = 0;
                PeriodPhase++;
                if (PeriodPhase == Period)
                {
                    PeriodPhase = 0;
                }
                CurrentFrame = FrameSequence[PeriodPhase];
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle((int) StartCoordinate.X + Width*CurrentFrame, (int) StartCoordinate.Y,
                Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class DeadMovingUpAndDownMarioSprite : ISprite
    {
        // Content manager to load texture
        private static ContentManager Content;

        // Kernal sprite information
        private static Texture2D Texture;
        private static Vector2 StartCoordinate = new Vector2(0, 16);
        private static Vector2 EndCoordinate = new Vector2(14, 29);

        // Computed sprite information
        private static int Width = (int)(EndCoordinate.X - StartCoordinate.X);
        private static int Height = (int)(EndCoordinate.Y - StartCoordinate.Y);

        // Static animation information
        private static int Period = 8;
        private static Vector2 LinearDisplacement = new Vector2(0, 20);
        private static int NumOfDisplacement = 5;
        private static int[] DisplacementSequence = { 0, 1, 2, 3, 4, 3, 2, 1 };

        // Dynamic animation information
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

        // Animation logic
        private Vector2 GetDisplacement()
        {
            return CurrentDisplacement*LinearDisplacement/NumOfDisplacement;
        }

        // State information
        public int DelayPhase { get; set; }
        public int PeriodPhase { get; set; }
        private int CurrentDisplacement;

        public DeadMovingUpAndDownMarioSprite(ContentManager content)
        {
            Content = content;
            TimeInterval = 10;
            DelayPhase = 0;
            PeriodPhase = 0;
            CurrentDisplacement = DisplacementSequence[PeriodPhase];
        }

        public void Load()
        {
            Texture = Content.Load<Texture2D>("mario");
        }

        public void Update()
        {
            DelayPhase++;
            if (DelayPhase == TimeInterval)
            {
                DelayPhase = 0;
                PeriodPhase++;
                if (PeriodPhase == Period)
                {
                    PeriodPhase = 0;
                }
                CurrentDisplacement = DisplacementSequence[PeriodPhase];
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location += GetDisplacement();
            Rectangle sourceRectangle = new Rectangle((int) StartCoordinate.X, (int) StartCoordinate.Y,
                Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class RunningLeftAndRightMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }
        public Vector2 Offset { get; set; }
        private Vector2 unitOffset;
        public int TotalFrames { get; set; }
        public int Interval { get; set; }
        private int phase;
        private int width;
        private int height;
        private int cycle;
        private int cyclePhase;
        private static int[] offsetSequence = {1, 2, 3, 4, 5, 6, 7, 7, 6, 5, 4, 3, 2, 1, 0, 0};
        private static int[] frameSequence = {7, 6, 5, 7, 6, 5, 4, 3, 0, 1, 2, 0, 1, 2, 3, 4};

        public RunningLeftAndRightMarioSprite(Texture2D texture, Vector2 start, Vector2 end, Vector2 offset, int frames, int interval)
        {
            Texture = texture;
            Start = start;
            End = end;
            TotalFrames = frames;
            Interval = interval;
            cycle = 16;
            cyclePhase = 0;
            phase = 0;
            Offset = offset;
            unitOffset = offset/cycle;
            width = (int) (End.X - Start.X)/frames;
            height = (int) (End.Y - Start.Y);
        }

        public void Load()
        {
            //Texture = Content.Load<Texture2D>("mario");
        }

        public void Update()
        {
            phase++;
            if (phase == Interval)
            {
                phase = 0;
                cyclePhase++;
                if (cyclePhase == cycle)
                {
                    cyclePhase = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location += unitOffset*offsetSequence[cyclePhase];
            Rectangle sourceRectangle = new Rectangle((int) Start.X + width*frameSequence[cyclePhase], (int) Start.Y,
                width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
