namespace SuperMario
{
    public abstract class EnemyStateControllerKernel<TEnemy, TSpriteState, TMotionState> 
        : StateControllerKernelNew<TSpriteState, TMotionState>, IEnemyStateController
        where TEnemy : class, IEnemy
        where TSpriteState : IEnemySpriteState, new()
        where TMotionState : IEnemyMotionState, new()
    {
        public bool Dead { get { return SpriteState.Dead; } }

        public bool NotMoving { get { return MotionState.DefaultHotizontal; } }

        public abstract void MarioSmash();

        public void Flip()
        {
            if (Dead) return;
            Core.Object.TurnUnsolid();
            Core.BarrierHandler.ClearBarrier();
            SoundManager.KickSoundPlay();
            SpriteState.Flip();
            MotionState.Flip();
            Display.AddScore<TEnemy>();
        }

        public void Turn(Orientation orientation = Orientation.Default)
        {
            if (orientation == Orientation.Default)
                orientation = (Orientation)(-(int)MotionState.Orientation);
            MotionState.Turn(orientation);
            SpriteState.SetOrientation(orientation);
        }

        public void KeepOnLand()
        {
            MotionState.LoseGravity();
        }

        public void LiftOff()
        {
            MotionState.ObtainGravity();
        }
    }
}