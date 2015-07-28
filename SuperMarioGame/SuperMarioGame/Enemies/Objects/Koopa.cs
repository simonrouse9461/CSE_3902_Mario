﻿namespace SuperMario
{
    public  class Koopa : EnemyKernel<KoopaStateController>
    {
        public bool IsMovingShell
        {
            get { return StateController.SpriteState.Dead && StateController.MotionState.IsMovingShell; }
        }
    }
}
