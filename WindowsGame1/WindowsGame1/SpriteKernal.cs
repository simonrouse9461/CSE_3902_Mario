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

        // Animation information
        public SpriteAnimation Animation;
    
        // Properties
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

        // States
        public int DelayPhase { get; set; }
        public int PeriodPhase { get; set; }

        // Constructor
        public SpriteKernal()
        {
            Initialize();
            Reset();
        }

        public abstract void Initialize();

        public void Reset()
        {
            DelayPhase = 0;
            PeriodPhase = 0;
        }

        public abstract void Load(ContentManager content);

        public void Update()
        {
            DelayPhase++;
            if (DelayPhase >= TimeInterval)
            {
                DelayPhase = 0;
                PeriodPhase++;
                if (PeriodPhase >= Animation.Period)
                {
                    PeriodPhase = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location += Animation.GetDisplacement(Animation.GetStage(PeriodPhase));
            Rectangle sourceRectangle = new Rectangle((int)Source.StartCoordinate.X + Source.Width * Animation.GetFrame(PeriodPhase), (int)Source.StartCoordinate.Y,
                Source.Width, Source.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Source.Width, Source.Height);
            spriteBatch.Draw(Source.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
