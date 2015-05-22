using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{

    public class RunningInPlaceMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }
        public int TotalFrames { get; set; }
        public int Interval { get; set; }
        private int phase;
        private int width;
        private int height;
        private int currentFrame;

        public RunningInPlaceMarioSprite(Texture2D texture, Vector2 start, Vector2 end, int frames, int interval)
        {
            Texture = texture;
            Start = start;
            End = end;
            TotalFrames = frames;
            Interval = interval;
            phase = 0;
            currentFrame = 0;
            width = (int) (End.X - Start.X)/frames;
            height = (int) (End.Y - Start.Y);
        }

        public void Update()
        {
            phase++;
            if (phase == Interval)
            {
                phase = 0;
                currentFrame++;
                if (currentFrame == TotalFrames)
                {
                    currentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle((int) Start.X + width*(TotalFrames - currentFrame- 1), (int) Start.Y,
                width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class DeadMovingUpAndDownMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }
        public Vector2 Offset { get; set; }
        private Vector2 unitOffset;
        private Vector2 currentOffset;
        public int TotalFrames { get; set; }
        public int Interval { get; set; }
        private int phase;
        private int width;
        private int height;
        private int currentFrame;
        private int increment;

        public DeadMovingUpAndDownMarioSprite(Texture2D texture, Vector2 start, Vector2 end, Vector2 offset, int frames, int interval)
        {
            Texture = texture;
            Start = start;
            End = end;
            TotalFrames = frames;
            Interval = interval;
            Offset = offset;
            unitOffset = offset/frames;
            currentFrame = 0;
            phase = 0;
            width = (int) (End.X - Start.X);
            height = (int) (End.Y - Start.Y);
            currentOffset = new Vector2(0, 0);
        }

        public void Update()
        {
            phase++;
            if (phase == Interval)
            {
                phase = 0;
                if (currentFrame == 0)
                {
                    increment = 1;
                }
                else if (currentFrame == TotalFrames)
                {
                    increment = -1;
                }
                currentFrame += increment;
                currentOffset += increment*unitOffset;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location += currentOffset;
            Rectangle sourceRectangle = new Rectangle((int) Start.X, (int) Start.Y,
                width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

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
