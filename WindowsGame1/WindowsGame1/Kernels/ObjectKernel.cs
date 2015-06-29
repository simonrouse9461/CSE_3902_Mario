using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel<TSpriteState, TMotionState> : IObject
        where TSpriteState : SpriteStateKernel
        where TMotionState : MotionStateKernel
    {
        // Wrapper that wraps all internal fields of the object
        protected State<TSpriteState, TMotionState> State { get; private set; }

        // Temporarily made for test cases
        public State<TSpriteState, TMotionState> StateGetter
        {
            get { return State; }
        }

        // Private fields
        private TSpriteState spriteState;
        private TMotionState motionState;
        private BarrierDetector barrierDetector;
        private ICollisionHandler collisionHandler;
        private ICommandExecutor commandExecutor;

        // Corresponding Properties to private fields
        protected TSpriteState SpriteState
        {
            get { return spriteState; }
            set
            {
                spriteState = value;
                State.SpriteState = value;
            }
        }

        protected TMotionState MotionState
        {
            get { return motionState; }
            set
            {
                motionState = value;
                State.MotionState = value;
            }
        }

        protected BarrierDetector BarrierDetector
        {
            get { return barrierDetector; }
            set
            {
                barrierDetector = value;
                State.BarrierDetector = value;
            }
        }

        protected ICommandExecutor CommandExecutor
        {
            get { return commandExecutor; }
            set
            {
                commandExecutor = value;
                State.CommandExecutor = value;
            }
        }

        protected ICollisionHandler CollisionHandler
        {
            get { return collisionHandler; }
            set
            {
                collisionHandler = value;
                State.CollisionHandler = value;
            }
        }

        // Constructor
        protected ObjectKernel()
        {
            State = new State<TSpriteState, TMotionState>
            {
                Object = this
            };
            BarrierDetector = new BarrierDetector(State);
        }

        // Properties
        public virtual bool Solid
        {
            get { return true; }
        }

        public virtual bool Stealth
        {
            get { return false; }
        }

        public bool GoingUp
        {
            get { return MotionState.Velocity.Y < 0; }
        }

        public bool GoingDown
        {
            get { return MotionState.Velocity.Y > 0; }
        }

        public bool GoingLeft
        {
            get { return MotionState.Velocity.X < 0; }
        }

        public bool GoingRight
        {
            get { return MotionState.Velocity.X > 0; }
        }

        public Rectangle PositionRectangle
        {
            get { return SpriteState.Sprite.GetDestination(MotionState.Position); }
        }

        public Vector2 PositionPoint
        {
            get { return MotionState.Position; }
        }

        // Methods
        protected abstract void SyncState();

        public virtual void Reset()
        {
            SpriteState.Reset();
            MotionState.Reset();
            State.ClearDelayedCommands();
            BarrierDetector.ClearBarrier();
        }

        public void Load(ContentManager content, Vector2 location)
        {
            SpriteState.Load(content);
            MotionState.Position = location;
        }

        public void Unload()
        {
            State.DelayCommand(state => WorldManager.Instance.RemoveObject(this));
        }

        public void Update()
        {
            State.Update();
            if (CommandExecutor != null) CommandExecutor.Execute();
            SyncState();
            if (CollisionHandler != null) CollisionHandler.Handle();
            SyncState();
            SpriteState.Update();
            MotionState.Update();
            BarrierDetector.Detect();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var relativePosition = MotionState.Position - Camera.Instance.Location;
            if (SpriteState.Left)
                SpriteState.Sprite.DrawLeft(spriteBatch, relativePosition, SpriteState.Color);
            else if (SpriteState.Right)
                SpriteState.Sprite.DrawRight(spriteBatch, relativePosition, SpriteState.Color);
            else
                SpriteState.Sprite.DrawDefault(spriteBatch, relativePosition, SpriteState.Color);
        }

        public void PassCommand(ICommand command)
        {
            CommandExecutor.ReadCommand(command);
        }
    }
}