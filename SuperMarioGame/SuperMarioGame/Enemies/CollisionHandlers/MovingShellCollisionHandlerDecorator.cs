using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class MovingShellCollisionHandlerDecorator : CollisionHandlerKernelNew<KoopaStateController>, IDecorator
    {
        public EnemyCollisionHandler DefaultCollisionHandler { get; private set; }

        public MovingShellCollisionHandlerDecorator(ICoreNew core) : base(core)
        {
            DefaultCollisionHandler = (EnemyCollisionHandler)core.CollisionHandler;
        }

        public void Restore()
        {
            Core.SwitchComponent(DefaultCollisionHandler);
            Core.StateController.Walk();
        }

        public void DelayRestore(int timeDelay)
        {
            Core.DelayCommand(Restore,
                () => Core.CollisionHandler is MovingShellCollisionHandlerDecorator
                      && Core.StateController.NotMoving, timeDelay);
        }

        public override void Handle()
        {
            DefaultCollisionHandler.HandleStarPower();
            HandleMario();
            DefaultCollisionHandler.HandleBlock();
            DefaultCollisionHandler.HandleBlockDebris();
            DefaultCollisionHandler.HandleFireball();
        }

        protected void HandleMario()
        {
            var collision = Core.CollisionDetector.Detect<Mario>();
            if (collision.Left.Touch || collision.TopLeft.Cover || collision.TopLeft.Touch && collision.TopRight.None)
                Core.StateController.PushShell(Orientation.Right);
            if (collision.Right.Touch || collision.TopRight.Cover || collision.TopRight.Touch && collision.TopLeft.None)
                Core.StateController.PushShell(Orientation.Left);
        }
    }
}