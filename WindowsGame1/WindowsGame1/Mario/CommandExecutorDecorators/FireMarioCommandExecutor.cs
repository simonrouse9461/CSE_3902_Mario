using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1.CommandExecutorDecorators
{
    public class FireMarioCommandExecutor : MarioCommandExecutor
    {
        public MarioCommandExecutor DefaultCommandExecutor { get; private set; }
        public FireMarioCommandExecutor(Core<MarioSpriteState, MarioMotionState> core, MarioCommandExecutor original) : base(core)
        {
            DefaultCommandExecutor = original;
            CommandAction.Add(typeof(MarioFireCommand), () =>
            {
                Core.SpriteState.Shoot();
                Core.Object.Generate(
                    new Vector2(Core.SpriteState.Left ? -10 : 10, -10),
                    Core.SpriteState.Left ? new FireballObject().LeftFireBall : new FireballObject().RightFireBall
                    );
            });
        }
    }
}