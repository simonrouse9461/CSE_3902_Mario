using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class EnemyBarrierHandler : AbstractBarrierHandlerKernel<IEnemyStateController>
    {
        public EnemyBarrierHandler(ICoreNew core) : base(core) { }

        public override void HandleCollision()
        {
            CheckFloor();
            CheckWall();
        }

        private void CheckFloor()
        {
            if (BarrierCollision.Bottom.Touch)
                AbstractStateController.KeepOnLand(); 
            else AbstractStateController.LiftOff();
        }

        private void CheckWall()
        {
            if (BarrierCollision.AnySide.Touch) AbstractStateController.Turn();
        }
    }
}