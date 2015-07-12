﻿using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MushroomCollisionHandler : CollisionHandlerKernelNew<MushroomStateController>
    {

        public MushroomCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            HandleMario();
        }

        protected virtual void HandleMario()
        {
            if (Core.CollisionDetector.Detect<MarioObject>().AnySide.Touch)
            {
                Core.Object.Unload();
            }
        }
    }
}