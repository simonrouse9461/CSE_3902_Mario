using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class MarioNew : ObjectKernelNew
    {
        private MarioSpriteState SpriteState;
        private MarioMotionState MotionState;

        public MarioNew(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new MarioSpriteState();
            MotionState = new MarioMotionState(location);
        }

        public override void Load(ContentManager content)
        {
            SpriteState.Load(content);
        }

        public override void Update()
        {
            SpriteState.Update();
            MotionState.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteState.ActiveSprite().Draw(spriteBatch, MotionState.CurrentLocation());
        }

        public override Vector2 GetLocation()
        {
            return MotionState.CurrentLocation();
        }


        public void FaceLeft()
        {
            SpriteState.Orientation = MarioSpriteState.OrientationEnum.Left;
        }

        public void FaceRight()
        {
            SpriteState.Orientation = MarioSpriteState.OrientationEnum.Right;
        }

        public void BecomeBig()
        {
            SpriteState.Status = MarioSpriteState.StatusEnum.Big;
        }

        public void BecomeDead()
        {
            SpriteState.Status = MarioSpriteState.StatusEnum.Dead;
        }

        public void BecomeFire()
        {
            SpriteState.Status = MarioSpriteState.StatusEnum.Fire;
        }

        public void GoDown()
        {
            switch (SpriteState.Action)
            {
                case MarioSpriteState.ActionEnum.Stand:
                    SpriteState.Action = MarioSpriteState.ActionEnum.Crouch;
                    break;
                case MarioSpriteState.ActionEnum.Run:
                    SpriteState.Action = MarioSpriteState.ActionEnum.Stand;
                    break;
                case MarioSpriteState.ActionEnum.Jump:
                    SpriteState.Action = MarioSpriteState.ActionEnum.Run;
                    break;
            }
        }

        public void BecomeSmall()
        {
            SpriteState.Status = MarioSpriteState.StatusEnum.Small;
        }

        public void GoUp()
        {
            switch (SpriteState.Action)
            {
                case MarioSpriteState.ActionEnum.Crouch:
                    SpriteState.Action = MarioSpriteState.ActionEnum.Stand;
                    break;
                case MarioSpriteState.ActionEnum.Stand:
                    SpriteState.Action = MarioSpriteState.ActionEnum.Run;
                    break;
                case MarioSpriteState.ActionEnum.Run:
                    SpriteState.Action = MarioSpriteState.ActionEnum.Jump;
                    break;
            }
        }

        public void StandStill()
        {
            SpriteState.Action = MarioSpriteState.ActionEnum.Stand;
        }
    }
}