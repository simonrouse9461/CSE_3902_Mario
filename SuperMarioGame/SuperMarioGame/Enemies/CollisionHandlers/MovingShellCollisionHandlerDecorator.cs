using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class MovingShellCollisionHandlerDecorator : EnemyCollisionHandler, IDecorator
    {
        public EnemyCollisionHandler DefaultCollisionHandler { get; private set; }

        public MovingShellCollisionHandlerDecorator(ICoreNew core) : base(core)
        {
            DefaultCollisionHandler = (EnemyCollisionHandler)core.CollisionHandler;
        }

        public void Restore()
        {
            AbstractCore.SwitchComponent(DefaultCollisionHandler);
        }

        public void DelayRestore(int timeDelay)
        {
            AbstractCore.DelayCommand(Restore, () => AbstractCore.CollisionHandler is MovingShellCollisionHandlerDecorator, timeDelay);
        }

        protected override void HandleKoopa()
        {
            
        }

        protected override void HandleMario()
        {
            
        }
    }
}