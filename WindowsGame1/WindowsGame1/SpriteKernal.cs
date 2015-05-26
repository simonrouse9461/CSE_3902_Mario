using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteKernal : ISprite
    {
        // Sprite source information
        public SingleLineSpriteSource Source;

        // A structure that defines how does the sprite animate
        public SpriteAnimation Animation;

        // The time interval between two updates
        private int _timeInterval = 10;

        public int TimeInterval
        {
            get { return _timeInterval; }
            set
            {
                _timeInterval = value;
                TimeIntervalCounter = 0;
            }
        }

        // States variables
        public int TimeIntervalCounter { get; set; }
        public int Phase { get; set; }

        // Constructor
        public SpriteKernal()
        {
            Initialize();
            Reset();
        }

        // Initialize sprite properties.
        public abstract void Initialize();

        // Reset states.
        public void Reset()
        {
            TimeIntervalCounter = 0;
            Phase = 0;
        }

        // Load image content.
        public abstract void Load(ContentManager content);

        // Update state.
        public void Update()
        {
            TimeIntervalCounter++;
            if (TimeIntervalCounter >= TimeInterval)
            {
                TimeIntervalCounter = 0;
                Phase++;
                if (Phase >= Animation.Period)
                {
                    Phase = 0;
                }
            }
        }

        // Draw on the canvas.
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location += Animation.GetDisplacement(Animation.GetStage(Phase));
            Rectangle sourceRectangle =
                new Rectangle((int) Source.StartCoordinate.X + Source.Width*Animation.GetFrame(Phase),
                    (int) Source.StartCoordinate.Y,
                    Source.Width, Source.Height);
            Rectangle destinationRectangle = new Rectangle((int) location.X, (int) location.Y, Source.Width,
                Source.Height);
            spriteBatch.Draw(Source.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}