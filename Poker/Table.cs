using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Table
    {
        protected List<Card> _currentCards = new List<Card>();
        protected string[] _asciiCards = new string[5];
        private Random random = new Random();
        private int numberOfDrawnCards = 0;
        private int pot = 0;

        public void getCardFromDeck(Card card)
        {
            _currentCards.Add(card);
            addCardToAscii(card);
            numberOfDrawnCards += 1;
        }

        public string[] returnCardsAsAscii()
        {
            return _asciiCards;
        }

        public int getNumberOfDrawnCards()
        {
            return numberOfDrawnCards;
        }

        public void printCardsAsAscii()
        {
            foreach(string asciiRow in _asciiCards)
            {
                Console.WriteLine(asciiRow);
            }
        }

        public void addCardToAscii(Card card)
        {
            string value = card.getHead();
            string symbol = card.getSuit();
            _asciiCards[0] += "+-----+  ";
            if (value == "10")
            {
                _asciiCards[1] += "| 1 0 |  ";
            }
            else
            {
                _asciiCards[1] += "|  " + value + "  |  ";
            }
            _asciiCards[2] += "|  " + symbol+  "  |  ";
            _asciiCards[3] += "|     |  ";
            _asciiCards[4] += "+-----+  ";
            
        }
        
        public List<Card> getCurrentCards()
        {
            return _currentCards;
        }

        public void removeCards()
        {
            _currentCards.Clear();
            for(int i = 0; i < _asciiCards.Length; i++)
            {
                _asciiCards[i] = "";
            }
            numberOfDrawnCards = 0;
        }
    }
}
