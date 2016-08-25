using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Card
    {
        
        private string _head;
        private string _suit;
        private int _randomizedValue;

        public Card(string head, string symbol, Random random)
        {
            _head = head;
            _suit = symbol;
            _randomizedValue = random.Next(10000);
        }

        public string getSuit()
        {
            return _suit;
        }

        public string getHead()
        {
            return _head;
        }
        
        public int getRandomizedValue()
        {
            return _randomizedValue;
        }

    }
}
