using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class QuestionBlockObject : IndestructibleBlockObject
    {
        public QuestionBlockObject()
        {
            SpriteState.QuestionBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }
    }
}
