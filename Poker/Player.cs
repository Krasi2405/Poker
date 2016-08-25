using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Player : Table
    {
        protected HandEvaluator evaluator;
        protected HandEvaluator evaluatorString;

        public Player()
        {
            evaluator = new HandEvaluator();
            evaluatorString = new HandEvaluator();
        }

        public HandEvaluator getEvaluator()
        {
            return evaluator;
        }

        public HandEvaluator getStringEvaluator()
        {
            return evaluatorString;
        }
        
        public void resetState()
        {
            removeCards();
            evaluator = new HandEvaluator();
            evaluatorString = new HandEvaluator();
        }

    }
}
