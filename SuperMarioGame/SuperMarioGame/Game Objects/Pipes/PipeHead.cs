using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class PipeHead : BasicBarrierObject<PipeHeadSprite>, IPipe
    {
        public bool IsSecret { get; private set; }

        public static PipeHead Secret
        {
            get { return new PipeHead {IsSecret = true}; }
        }
    }
}
