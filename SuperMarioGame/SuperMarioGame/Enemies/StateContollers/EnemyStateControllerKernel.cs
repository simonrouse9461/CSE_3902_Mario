﻿namespace SuperMario
{
    public abstract class EnemyStateControllerKernel<TEnemy, TSpriteState, TMotionState> 
        : StateControllerKernelNew<TSpriteState, TMotionState>, IEnemyStateController
        where TEnemy : class, IEnemy
        where TSpriteState : IEnemySpriteState, new()
        where TMotionState : IEnemyMotionState, new()
    {
        public abstract void MarioSmash();

        public void Flip()
        {
            if (SpriteState.Dead) return;

            SoundManager.KickSoundPlay();
            MotionState.Flip();
            SpriteState.Flip();

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