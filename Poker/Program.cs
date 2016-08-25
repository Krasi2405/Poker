using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        public static void printUI(Table table, string[] playerCards, string[] aiCards)
        {
            Console.OutputEncoding = Encoding.Unicode;

            string whitespace = configureWhitespace(table);

            // Print AI cards
            foreach (string rowOfCard in aiCards)
            {
                Console.WriteLine("                                    " + rowOfCard);
            }

            // Print table
            string[] asciiCards = table.returnCardsAsAscii();
            Console.WriteLine("                    ==================================================");
            Console.WriteLine("                  //                                                  \\\\    ");
            foreach(string rowOfCard in asciiCards)
            {
                Console.WriteLine("                 ||    " + rowOfCard + whitespace + "   ||");
            }
            Console.WriteLine("                  \\\\                                                  //    ");
            Console.WriteLine("                     ==================================================");
            // Print player cards
            foreach(string rowOfCard in playerCards)
            {
                Console.WriteLine("                                    " + rowOfCard);
            }
            Console.WriteLine();
        }

        public static int compareHands(HandEvaluator evaluator1, HandEvaluator evaluator2) {
            
            // Returns 1 if player with cards1 has better cards
            // Returns 2 if player with cards2 has better cards
            // Returns 3 if the players have same power cards
            

            int[] hand1Points = evaluator1.returnResultAsInt();
            int[] hand2Points = evaluator2.returnResultAsInt();

            for(int i = 0; i < hand1Points.Length; i++)
            {
                if (hand1Points[i] > hand2Points[i])
                {
                    return 1;
                }
                else if(hand1Points[i] < hand2Points[i])
                {
                    return 2;
                }
                else
                {
                    continue;
                }
            }
            return 3;
        }

        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Table table = new Table();
            Player player = new Player();
            AI ai = new AI();

            Random random = new Random();


            string[] hiddenCards = new string[5];
            for (int i = 0; i <= 1; i++)
            {
                hiddenCards[0] += "+-----+  ";
                hiddenCards[1] += "|     |  ";
                hiddenCards[2] += "|     |  ";
                hiddenCards[3] += "|     |  ";
                hiddenCards[4] += "+-----+  ";
            }


            // GAME LOOP
            while (true)
            {

                deck.getNewCards();
                deck.shuffleDeck();

                ai.getCardFromDeck(deck.getRandomCard());
                ai.getCardFromDeck(deck.getRandomCard());

                player.getCardFromDeck(deck.getRandomCard());
                player.getCardFromDeck(deck.getRandomCard());

                printUI(table, player.returnCardsAsAscii(), hiddenCards);
                Console.ReadLine();
                Console.Clear();

                table.getCardFromDeck(deck.getRandomCard());
                table.getCardFromDeck(deck.getRandomCard());
                table.getCardFromDeck(deck.getRandomCard());
                printUI(table, player.returnCardsAsAscii(),hiddenCards);
                Console.ReadLine();
                Console.Clear();

                table.getCardFromDeck(deck.getRandomCard());
                printUI(table, player.returnCardsAsAscii(), hiddenCards);
                Console.ReadLine();
                Console.Clear();

                table.getCardFromDeck(deck.getRandomCard());
                printUI(table, player.returnCardsAsAscii(), hiddenCards);
                Console.ReadLine();
                Console.Clear();

                printUI(table, player.returnCardsAsAscii(), ai.returnCardsAsAscii());

                player.getEvaluator().addCardList(player.getCurrentCards());
                player.getEvaluator().addCardList(table.getCurrentCards());

                player.getStringEvaluator().addCardList(player.getCurrentCards());
                player.getStringEvaluator().addCardList(table.getCurrentCards());

                ai.getEvaluator().addCardList(ai.getCurrentCards());
                ai.getEvaluator().addCardList(table.getCurrentCards());

                ai.getStringEvaluator().addCardList(ai.getCurrentCards());
                ai.getStringEvaluator().addCardList(table.getCurrentCards());

                int score = compareHands(player.getEvaluator(), ai.getEvaluator());

                Console.WriteLine("Player has " + player.getStringEvaluator().returnResultAsString() + "\n" + player.getStringEvaluator().getHighCardAsString() + " high card.");
                Console.WriteLine();
                Console.WriteLine("AI has " + ai.getStringEvaluator().returnResultAsString() + "\n" + ai.getStringEvaluator().getHighCardAsString() + " high card.");
                
                Console.WriteLine();
                if (score == 1)
                {
                    Console.WriteLine("The Player has won.");
                }
                else if(score == 2)
                {
                    Console.WriteLine("The AI has won.");
                }
                else if(score == 3)
                {
                    Console.WriteLine("The Player splits the pot with the AI.");
                }
                Console.ReadLine();
                Console.Clear();
                
                table = new Table();
                ai.resetState();
                player.resetState();
               
                Console.Clear();
            }
        }

        

        public static string configureWhitespace(Table table)
        {
            string whitespace = "";
            if (table.getNumberOfDrawnCards() == 0)
            {
                whitespace = "                                             ";
            }
            else if (table.getNumberOfDrawnCards() == 1)
            {
                whitespace = "                                    ";
            }
            else if (table.getNumberOfDrawnCards() == 2)
            {
                whitespace = "                           ";
            }
            else if (table.getNumberOfDrawnCards() == 3)
            {
                whitespace = "                  ";
            }
            else if (table.getNumberOfDrawnCards() == 4)
            {
                whitespace = "         ";
            }
            return whitespace;
        }

        

    }
}
