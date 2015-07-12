using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class QuestionBlockObject : BlockKernel
    {
        private enum Version
        {
            Item,
            Coin,
            Default
        }
      
        private Version version;

        public QuestionBlockObject()
        {
            StateController.QuestionBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        public static QuestionBlockObject ItemQuestionBlock
        {
            get
            {
                return new QuestionBlockObject
                {
                    version = Version.Item
                };              
            }
        }

        public static QuestionBlockObject CoinQuestionBlock
        {
            get
            {
                return new QuestionBlockObject
                {
                    version = Version.Coin
                };           
            }
        }
    }
}
