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

        public QuestionBlockObject ItemQuestionBlock
        {
            get
            {
                version = Version.Item;
                return this;
            }
        }

        public QuestionBlockObject CoinQuestionBlock
        {
            get
            {
                version = Version.Coin;
                return this;
            }
        }
    }
}
