using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Deck
    {
        private List<Card> _cards = new List<Card>();
        private string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] asciiCards = new string[5];
        private Random random = new Random();

        public Card getRandomCard()
        {
            int index = random.Next(_cards.Count);
            Card card = _cards.ElementAt(index);
            _cards.RemoveAt(index);
            return card;
        }

        public void removeAllCards()
        {
            _cards.Clear();
        }

        public void getNewCards()
        {
            removeAllCards();
            for (int i = 0; i < values.Length; i++)
            {
                string symbol = "";
                for (int a = 0; a < 4; a++)
                {
                    if(a == 0)
                    {
                        symbol = "♠";
                    }
                    else if(a == 1)
                    {
                        symbol = "♥";
                    }
                    else if (a == 2)
                    {
                        symbol = "♦";
                    }
                    else if (a == 3)
                    {
                        symbol = "♣";
                    }

                    _cards.Add(new Card(values[i], symbol, random));
                }
            }
            shuffleDeck();
        }

        public void shuffleDeck()
        {
            _cards = _cards.OrderBy(a => a.getRandomizedValue()).ToList<Card>();
        }

        public void printCards()
        {
            foreach (Card card in _cards)
            {
                Console.WriteLine(card.getHead());
            }
        }
        
    }
}
