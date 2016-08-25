using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class HandEvaluator
    {
        private List<Card> _currentCards = new List<Card>();
        private bool hasPair = false;
        private bool hasTwo = false;
        private bool hasThree = false;
        private bool hasFour = false;
        private bool hasFlush = false;
        private bool hasStraight = false;

        public HandEvaluator()
        {

        }

        public HandEvaluator(List<Card> cards)
        {
            _currentCards = cards;
        }

        public void resetState()
        {
            _currentCards.Clear();
            _currentCards = new List<Card>();
            bool hasPair = false;
            bool hasTwo = false;
            bool hasThree = false;
            bool hasFour = false;
            bool hasFlush = false;
            bool hasStraight = false;
    }

        public string returnResultAsString()
        {
            
            int highCard = getHighCard();
            string suit = checkForFlush();
            int[] highAndLowStraight = checkForStraight();
            string[] pairsTable = checkForPairs();

            // Royal Flush
            if (hasFlush && hasStraight && highAndLowStraight[1] == 14)
            {
                return " royal flush.";
            }

            // Straight Flush
            else if (hasFlush && hasStraight)
            {
                string straightHigh = "";
                if (highAndLowStraight[1] == 11)
                {
                    straightHigh = "J";
                }
                else if (highAndLowStraight[1] == 12)
                {
                    straightHigh = "Q";
                }
                else if (highAndLowStraight[1] == 13)
                {
                    straightHigh = "K";
                }
                else if (highAndLowStraight[1] == 14)
                {
                    straightHigh = "A";
                }
                else
                {
                    straightHigh = highAndLowStraight[1] + "";
                }
                return "a straight flush ranging to " + straightHigh + ".";
            }

            // Four Of a Kind
            else if (hasFour)
            {
                return "four " + pairsTable[2] + " of a kind.";
            }

            // Full House
            else if (hasThree && hasPair)
            {
                return pairsTable[1] + " full of " + pairsTable[0] + ".";
            }

            // Flush
            else if (hasFlush)
            {
                return "a flush";
            }

            // Straight
            else if (hasStraight)
            {
                string straightHigh = "";
                if (highAndLowStraight[1] == 11)
                {
                    straightHigh = "J";
                }
                else if (highAndLowStraight[1] == 12)
                {
                    straightHigh = "Q";
                }
                else if (highAndLowStraight[1] == 13)
                {
                    straightHigh = "K";
                }
                else if (highAndLowStraight[1] == 14)
                {
                    straightHigh = "A";
                }
                else
                {
                    straightHigh = highAndLowStraight[1] + "";
                }
                return "a straight ranging to " + straightHigh + ".";
            }

            // Three Of a Kind
            else if (hasThree)
            {
                return "three " + pairsTable[1] + " of a kind.";
            }

            // Two Pairs
            else if (hasTwo && hasPair)
            {
                return "two pairs of " + pairsTable[0] + " and " + pairsTable[3];
            }

            // Pair
            else if (hasPair)
            {
                return "a pair of " + pairsTable[0] + ".";
            }
            else
            {
                string high = "";
                if (highCard == 11)
                {
                    high = "J";
                }
                else if (highCard == 12)
                {
                    high = "Q";
                }
                else if (highCard == 13)
                {
                    high = "K";
                }
                else if (highCard == 14)
                {
                    high = "A";
                }
                else
                {
                    high = highCard + "";
                }
                return "a " + high + " high card";
            };
        }

        public int[] returnResultAsInt()
        {
            int highCard = getHighCard();
            string suit = checkForFlush();
            int[] highAndLowStraight = checkForStraight();
            string[] pairsTable = checkForPairs();
            

            int[] points = new int[3];
            points[0] = 0;
            points[1] = 0;
            // Royal Flush
            // [0] - 9, [1] - 0, [2] - 0
            if (hasFlush && hasStraight && highAndLowStraight[1] == 14)
            {
                points[0] = 9;
            }

            // Straight Flush
            // [0] - 8, [1] - largest straight value, [2] - high card as int
            else if (hasFlush && hasStraight)
            {
                points[0] = 8;
                points[1] = highAndLowStraight[1];
            }

            // Four Of a Kind
            // [0] - 7, [1] largest pair value, [2] - high card as int
            else if (hasFour)
            {
                points[0] = 7;
                string cardHead = pairsTable[2];

                if (cardHead == "J")
                {
                    points[1] = 11;
                }
                else if (cardHead == "Q")
                {
                    points[1] = 12;
                }
                else if (cardHead == "K")
                {
                    points[1] = 13;
                }
                else if (cardHead == "A")
                {
                    points[1] = 14;
                }
                else
                {
                    points[1] = Int32.Parse(cardHead);
                }
            }

            // Full House
            // [0] - 6, [1] largest pair value, [2] - high card as int
            else if (hasThree && hasPair)
            {
                points[0] = 6;
                string cardHead = pairsTable[1];
                if (cardHead == "J")
                {
                    points[1] = 11;
                }
                else if (cardHead == "Q")
                {
                    points[1] = 12;
                }
                else if (cardHead == "K")
                {
                    points[1] = 13;
                }
                else if (cardHead == "A")
                {
                    points[1] = 14;
                }
                else
                {
                    points[1] = Int32.Parse(cardHead);
                }
            }

            // Flush
            // [0] - 5, [1] - 0, [2] - high card as int
            else if (hasFlush)
            {
                points[0] = 5;
            }

            // Straight
            // [0] - 4, [1] largest number of straight, [2] - high card as int
            else if (hasStraight)
            {
                points[0] = 4;
                points[1] = highAndLowStraight[1];
            }

            // Three Of a Kind
            // [0] - 3, [1] - largest pair value, [2] - high card as int
            else if (hasThree)
            {
                points[0] = 3;
                string cardHead = pairsTable[1];
                if (cardHead == "J")
                {
                    points[1] = 11;
                }
                else if (cardHead == "Q")
                {
                    points[1] = 12;
                }
                else if (cardHead == "K")
                {
                    points[1] = 13;
                }
                else if (cardHead == "A")
                {
                    points[1] = 14;
                }
                else
                {
                    points[1] = Int32.Parse(cardHead);
                }
            }

            // Two Pairs
            // [0] - 2, [1] - largest pair value, [2] - high card as int
            else if (hasTwo && hasPair)
            {
                points[0] = 2;
                string cardHead = pairsTable[3];
                int value = 0;
                for (int i = 0; i <= 1; i++)
                {
                    try
                    {

                        if (value < Int32.Parse(cardHead))
                        {
                            value = Int32.Parse(cardHead);
                        }
                    }
                    catch (FormatException)
                    {
                        if (cardHead == "J")
                        {
                            if (value < 11)
                            {
                                value = 11;
                            }
                        }
                        else if (cardHead == "Q")
                        {
                            if (value < 12)
                            {
                                value = 12;
                            }
                        }
                        else if (cardHead == "K")
                        {
                            if (value < 13)
                            {
                                value = 13;
                            }
                        }
                        else if (cardHead == "A")
                        {
                            if (value < 14)
                            {
                                value = 14;
                            }
                        }
                        
                    }
                    cardHead = pairsTable[0];
                }
                points[1] = value;
            }

            // Pair
            // [0] - 1, [1] - pairs value, [2] - high card as int
            else if (hasPair)
            {
                points[0] = 1;
                string cardHead = pairsTable[0];
                try
                {
                    points[1] = Int32.Parse(cardHead);
                }
                catch (FormatException)
                {
                    if (cardHead == "J")
                    {
                        points[1] = 11;
                    }
                    else if (cardHead == "Q")
                    {
                        points[1] = 12;
                    }
                    else if (cardHead == "K")
                    {
                        points[1] = 13;
                    }
                    else if (cardHead == "A")
                    {
                        points[1] = 14;
                    }
                }
            }

            // High card
            // [0] - 0, [1] - 0, [2] - high card as int
            points[2] = highCard;

            return points;
        }

        public void newCards(List<Card> cards)
        {
            _currentCards = cards;
            bool hasPair = false;
            bool hasThree = false;
            bool hasFour = false;
            bool hasFlush = false;
            bool hasStraight = false;
        }

        public void evaluateHand()
        {
            checkForStraight();
            checkForFlush();
            checkForPairs();
        }

        public string[] checkForPairs()
        {
            // Checks whether there are any pairs, 
            // if there are it updates the HandEvaluator bool properties
            // and returns the pairs with an array
            // [0] - Pair
            // [1] - Three of a kind
            // [2] - Four of a kind
            // [3] - Second pair

            Dictionary<string, int> lookupTable = new Dictionary<string, int>();
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] pairsString = new string[4];
            foreach (string value in values)
            {
                lookupTable.Add(value, 0);
            }

            foreach(Card card in _currentCards)
            {
                lookupTable[card.getHead()] += 1;
            }

            foreach (KeyValuePair<string, int> kvp in lookupTable)
            {
                if(kvp.Value == 2 && hasPair == true && kvp.Key != pairsString[0])
                {
                    hasTwo = true;
                    pairsString[3] = kvp.Key;
                }

                else if (kvp.Value == 2)
                {
                    hasPair = true;
                    pairsString[0] = kvp.Key;
                }
                

                if (kvp.Value == 3)
                {
                    hasThree = true;
                    pairsString[1] = kvp.Key;
                }
                if (kvp.Value == 4)
                {
                    hasFour = true;
                    pairsString[2] = kvp.Key;
                }
            }
            return pairsString;
            
        }

        

        public int[] checkForStraight()
        {
            // Checks for straight
            // [0] is lowest int value of straight
            // [1] is largest int value of straight
            List<int> values = new List<int>();
            int[] highAndLow = new int[2];
            foreach (Card card in _currentCards)
            {
                if(card.getHead()== "J")
                {
                    values.Add(11);
                }
                else if (card.getHead() == "Q")
                {
                    values.Add(12);
                }
                else if (card.getHead() == "K")
                {
                    values.Add(13);
                }
                else if (card.getHead() == "A")
                {
                    values.Add(14);
                    values.Add(1);
                }
                else
                {
                    values.Add(Int32.Parse(card.getHead()));
                }
            }

            values.Sort();
            int check = 0;

            for (int i = 1; i <= 14; i++)
            {
                check = 0;
                for (int a = 0; a < values.Count; a++)
                {
                    if (i + a == values[a])
                    {
                        check += 1;
                    }

                    if (check >= 5)
                    {
                        hasStraight = true;
                        highAndLow[0] = values[0];
                        if ((values[a] - 1 == values[a - 1])) {
                            highAndLow[1] = values[a];
                        }
                    }
                }
                
            }
            return highAndLow;
        }

        public string checkForFlush()
        {
            // Checks for flush
            // If there is one returns the suit of the flush
            // Else returns a blank string

            int counter = 1;
            int largestCounter = 0;
            foreach(Card card in _currentCards)
            {
                counter = 1;
                foreach (Card card1 in _currentCards)
                {
                    if(card != card1 && card.getSuit() == card1.getSuit())
                    {
                        counter += 1;
                    }

                    if (counter >= 5)
                    {
                        hasFlush = true;
                        return card.getSuit();
                    }
                }
            }
            return "";
        }

        public int getHighCard()
        {
            // Returns the highest card's value

            int highestValue = 0;
            foreach(Card card in _currentCards)
            {
                int value = 0;
                if (card.getHead() == "J")
                {
                    value = 11;
                }
                else if (card.getHead() == "Q")
                {
                    value = 12;
                }
                else if (card.getHead() == "K")
                {
                    value = 13;
                }
                else if (card.getHead() == "A")
                {
                    value = 14;
                }
                else
                {
                    value = Int32.Parse(card.getHead());
                }

                if(highestValue < value)
                {
                    highestValue = value;
                }
            }
            return highestValue;
        }

        public string getHighCardAsString()
        {
            int highCard = getHighCard();
            string highCardAsString = "";
            if (highCard == 11)
            {
                highCardAsString = "J";
            }
            else if (highCard == 12)
            {
                highCardAsString = "Q";
            }
            else if (highCard == 13)
            {
                highCardAsString = "K";
            }
            else if (highCard == 14)
            {
                highCardAsString = "A";
            }
            else
            {
                highCardAsString = highCard + "";
            }
            return highCardAsString;
        }

        public void addCardList(List<Card> cards)
        {
            foreach(Card card in cards)
            {
                _currentCards.Add(card);
            }
        }

        public void removeCards()
        {
            _currentCards.Clear();
        }

        public bool getHasFlush()
        {
            return hasFlush;
        }

        public bool getHasStraight()
        {
            return hasStraight;
        }

        public bool getHasPair()
        {
            return hasPair;
        }

        public bool getHasThree()
        {
            return hasThree;
        }

        public bool getHasFour()
        {
            return hasFour;
        }
    }
}
