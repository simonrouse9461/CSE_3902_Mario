using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class QuestionBlockObject : BlockKernel
    {

        public QuestionBlockObject()
        {
            StateController.QuestionBlock();
            CollisionHandler = new QuestionBlockCollisionHandler(Core);
        }

        public static QuestionBlockObject ItemQuestionBlock
        {
            get
            {
                var instance = new QuestionBlockObject();
                instance.Core.StateController.PutItem();
                return instance;
            }
        }

        public static QuestionBlockObject CoinQuestionBlock
        {
            get
            {
                var instance = new QuestionBlockObject();
                instance.Core.StateController.PutCoin();
                return instance;
            }
        }       
    }
}
