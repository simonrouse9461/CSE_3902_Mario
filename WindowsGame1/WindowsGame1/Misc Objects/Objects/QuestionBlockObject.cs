﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class QuestionBlockObject : BlockKernel
    {
        public enum Version
        {
            Item,
            Coin,
            Default
        }
      
        public Version version = Version.Default;

        public QuestionBlockObject()
        {
            StateController.QuestionBlock();
            CollisionHandler = new QuestionBlockCollisionHandler(Core);
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

        public bool isItem
        {
            get
            {
                return version == Version.Item;
            }
        }

        
    }
}
