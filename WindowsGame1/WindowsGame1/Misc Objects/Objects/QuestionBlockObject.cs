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
            CollisionHandler = new BlockCollisionHandler(Core);
        }
    }
}
