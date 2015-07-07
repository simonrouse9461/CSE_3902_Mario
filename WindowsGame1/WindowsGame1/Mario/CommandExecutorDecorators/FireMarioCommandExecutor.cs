using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1.CommandExecutorDecorators
{
    public class FireMarioCommandExecutor : MarioCommandExecutor
    {
        public MarioCommandExecutor DefaultCommandExecutor { get; private set; }
        public FireMarioCommandExecutor(CoreNew<MarioStateController> core, MarioCommandExecutor original) : base(core)
        {
            DefaultCommandExecutor = original;
            RegisterCommand(typeof(MarioFireCommand), null, () =>
            {
                Core.StateController.SpriteState.Shoot();
                Core.Object.Generate(
                    new Vector2(Core.StateController.SpriteState.Left ? -10 : 10, -10),
                    Core.StateController.SpriteState.Left ? new FireballObject().LeftFireBall : new FireballObject().RightFireBall
                    );
            });
        }
    }
}