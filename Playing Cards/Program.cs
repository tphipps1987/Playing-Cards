// Class:           Playing Cards
// Author:          Tony Phipps
// Contact:         tony@phippstech.com
// Date created:    30JUL17
// Version:         1.0.0
// This was produced as part of a coding excercise to create methods to work with a deck of 52 playing cards.
// The methods were to order the deck orderDeck() and shuffle the deck shuffleDeck().
// Some extra methods and classes were created to facilitate this excercise.

using System;

namespace Playing_Cards
{
    public class Card
    {
        // Field
        public char suit; // H, C, S, D
        public string rank; // A,2,3,4,5,6,7,8,9,10,J,Q,K,Joker

        // Costructor with two parameters
        public Card(char s, string r)
        {
            if (s == 'C' || s == 'D' || s == 'H' || s == 'S' || s == ' ')
            {
                suit = s;
            }
            else
            {
                Console.WriteLine("\nUnexpected suit requested in Card constrcutor.");
                suit = ' ';
            }
            if (r == "A" || r == "J" || r == "Q" || r == "K" || r == "2" ||
                r == "3" || r == "4" || r == "5" || r == "6" || r == "7" ||
                r == "8" || r == "9" || r == "10" || r == "Joker")
            {
                rank = r;
            }
            else
            {
                Console.WriteLine("\nUnexpected rank requested in Card constrcutor.");
                rank = "Joker";
            }
        }

        // Method to return value of card
        // General guidelines will be to give greater value of suit based on alpha which is similar to bridge game
        public int GetValue()
        {
            int value = 0;
            switch (this.suit)
            {
                case 'C':   // Clubs   
                    value += 0;
                    break;
                case 'D':   // Diamonds
                    value += 13;
                    break;
                case 'H':   // Hearts
                    value += 26;
                    break;
                case 'S':   // Spades
                    value += 39;
                    break;
                case ' ':  // no suit
                    value += 0;
                    break;
                default:
                    break;
            }

            switch (this.rank)
            {
                case "2":
                    value += 1;
                    break;
                case "3":
                    value += 2;
                    break;
                case "4":
                    value += 3;
                    break;
                case "5":
                    value += 4;
                    break;
                case "6":
                    value += 5;
                    break;
                case "7":
                    value += 6;
                    break;
                case "8":
                    value += 7;
                    break;
                case "9":
                    value += 8;
                    break;
                case "10":
                    value += 9;
                    break;
                case "J":
                    value += 10;
                    break;
                case "Q":
                    value += 11;
                    break;
                case "K":
                    value += 12;
                    break;
                case "A":
                    value += 13;
                    break;
                case "Joker":
                    value = 0;  // zero out any valiue set by suit
                    break;
                default:
                    break;

            }
            return value;
 
        }
    }

    public class Deck
    {
        // Field(s)
        public Card[] deck;
        public int count;

        // Constructor with single parameter of deck size
        public Deck(int size)
        {
            char sd;
            string rd;

            if (size==52)
            {
                deck = new Card[size];
                int i = 0;
                while (i < (size-1))
                {

                    for (int suitD = 0; suitD <= 3; suitD++)
                    {
                        if (suitD == 0)
                        {
                            sd = 'C'; // Clubs
                        }
                        else if (suitD == 1)
                        {
                            sd = 'D'; // Diamonds
                        }
                        else if (suitD == 2)
                        {
                            sd = 'H'; // Hearts
                        }
                        else if (suitD == 3)
                        {
                            sd = 'S'; // Spades
                        }
                        else
                        {
                            // unexpected suit request, assign no suit
                            sd = '\0'; // Null for non-suit
                        }

                        // Set rank of cards
                        for (int rank = 0; rank < 13; rank++)
                        {
                            // Classify face cards followed by numbered cards
                            if (rank == 0)
                            {
                                rd = "A"; // Ace
                            }
                            else if (rank == 10)
                            {
                                rd = "J"; // Jack
                            }
                            else if (rank == 11)
                            {
                                rd = "Q"; // Queen
                            }
                            else if (rank == 12)
                            {
                                rd = "K"; // King
                            }
                            else
                            {
                                // all non face cards
                                rd = (rank+1).ToString();
                            }

                            deck[i] = new Card(sd, rd);
                            i++;
                        }
                    }
                }
            }
            else
            {
                // non standard deck size of 52, will provide one card a Joker
                Console.WriteLine("Please input only 52 card deck size");
                deck = new Card[1];
                deck[0] = new Card('J', "Joker");
            }
        }

        // method to print deck
        public void OutputDeck()
        {
            int i = 0;
            Console.WriteLine("Index, Rank, Suit");
            while (i < this.deck.Length)
            {
                Console.WriteLine(i.ToString() + ", " + this.deck[i].rank + ", " + this.deck[i].suit);
                i++;
            }
        }

        // method to shuffle deck
        public void ShuffleDeck()
        {
            Random random = new Random();

            // shuffle deck starting at top and working to bottom adjusting max random as progress to bottom
            int i = this.deck.Length - 1;
            while (i >= 0)
            {
                Card tmp = this.deck[i]; // assign this deck card to tmp
                int ri = random.Next(i); // get a new random selection
                
                // Swap positions
                this.deck[i] = this.deck[ri];
                this.deck[ri] = tmp;
                i--;
            }
        }

        // method to order deck
        public void OrderDeck()
        {

            int i = 0;
            while (i < this.deck.Length && this.deck.Length > 1)
            {
                if (this.deck[i].GetValue() > i + 1)
                {
                    // store card in tmp
                    Card tmp = this.deck[i];

                    // iterate through deck from end to start evaluating value of card until find the appropriate card for position i
                    for (int vi = this.deck.Length - 1; vi > i; vi--)
                    {
                        if (this.deck[vi].GetValue() == i + 1)
                        {
                            // tmp matched order, swap positions
                            this.deck[i] = this.deck[vi];
                            this.deck[vi] = tmp;
                        }
                        else
                        {
                            // tmp does not match, no swap
                        }
                    }
                }
                else
                {
                    // current card in position i is correct value for postion i
                    // no looping required
                }
                // iterate to next position in deck
                i++;

            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Playing Cards class and test scripts were created by Tony Phipps.");
            
            // testing of Card functionality
            Console.WriteLine("Suit=C,D,H,S; Rank=A,2,3,4,5,6,7,8,9,10,J,Q,K,Joker");
            Console.WriteLine("Input card (Suit, Rank)");
            string inputCard = Console.ReadLine();
            string[] split = inputCard.Split(',');
            char newSuit = char.Parse(split[0]);
            string newRank = split[1];

            Card testCard = new Card(newSuit, newRank);
            Console.WriteLine(testCard.suit + ", " + testCard.rank + ", " + testCard.GetValue());

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Test of blank suit, null rank");
            testCard = new Card(' ', null);
            Console.WriteLine(testCard.suit + ", " + testCard.rank + ", " + testCard.GetValue());

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Test of blank suit, Joker rank");
            testCard = new Card(' ', "Joker");
            Console.WriteLine(testCard.suit + ", " + testCard.rank + ", " + testCard.GetValue());

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Test of blank suit, strange rank");
            testCard = new Card(' ', "strange");
            Console.WriteLine(testCard.suit + ", " + testCard.rank + ", " + testCard.GetValue());

            // testing of Deck functionality
            Console.WriteLine("\nWould you like a deck of cards?");
            string inputDeck = Console.ReadLine();
            if (inputDeck == "Y" || inputDeck == "y" || inputDeck == "Yes" || inputDeck == "yes")
            {
                Deck testDeck = new Deck(52);

                // report deck size
                Console.WriteLine("The deck has " + testDeck.deck.Length + " cards.");

                // display deck after creation
                Console.WriteLine("\nThe deck after creation.");
                testDeck.OutputDeck();  // Call method to output deck

                testDeck.ShuffleDeck(); // Call method to shuffle deck

                // display deck after shuffle
                Console.WriteLine("\nThe deck after shuffle.");
                testDeck.OutputDeck();  // Call method to output deck

                testDeck.OrderDeck();   // Call method to re-order deck

                // display deck after re-order
                Console.WriteLine("\nThe deck after ordering.");
                testDeck.OutputDeck();  // Call method to output deck

                testDeck.ShuffleDeck(); // Call method to shuffle deck

                // display deck after second shuffle
                Console.WriteLine("\nThe deck after second shuffle.");
                testDeck.OutputDeck();  // Call method to output deck

                testDeck.ShuffleDeck(); // Call method to shuffle deck

                // display deck after third shuffle
                Console.WriteLine("\nThe deck after third shuffle.");
                testDeck.OutputDeck();  // Call method to output deck

                testDeck.OrderDeck();   // Call method to re-order deck

                // display deck after second re-order
                Console.WriteLine("\nThe deck after second ordering.");
                testDeck.OutputDeck();  // Call method to output deck

                testDeck.OrderDeck();   // Call method to re-order deck

                // display deck after third re-order
                Console.WriteLine("\nThe deck after third ordering.");
                testDeck.OutputDeck();  // Call method to output deck
                                        
                // test deck costructor unexpected size
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("Test deck size 50");
                testDeck = new Deck(50);
                // report deck size
                Console.WriteLine("The deck has " + testDeck.deck.Length + " cards.");

                // test shuffle with 1 card deck
                testDeck.ShuffleDeck();
                
                // display deck after shuffle
                Console.WriteLine("\nThe deck after shuffle.");
                testDeck.OutputDeck();  // Call method to output deck

                // test re-order with 1 card deck
                testDeck.OrderDeck();   // Call method to re-order deck

                // display deck after re-order
                Console.WriteLine("\nThe deck after ordering.");
                testDeck.OutputDeck();  // Call method to output deck

                // display deck after creation
                Console.WriteLine("\nThe deck after creation.");
                testDeck.OutputDeck();  // Call method to output deck

                // test deck costructor unexpected size
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("Test deck size 100");
                testDeck = new Deck(100);
                // report deck size
                Console.WriteLine("The deck has " + testDeck.deck.Length + " cards.");

                // display deck after creation
                Console.WriteLine("\nThe deck after creation.");
                testDeck.OutputDeck();  // Call method to output deck

                // test deck costructor 0 size
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("Test deck size 0");
                testDeck = new Deck(0);
                // report deck size
                Console.WriteLine("The deck has " + testDeck.deck.Length + " cards.");

                // display deck after creation
                Console.WriteLine("\nThe deck after creation.");
                testDeck.OutputDeck();  // Call method to output deck

                // test deck costructor -1 size
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("Test deck size -1");
                testDeck = new Deck(-1);
                // report deck size
                Console.WriteLine("The deck has " + testDeck.deck.Length + " cards.");

                // display deck after creation
                Console.WriteLine("\nThe deck after creation.");
                testDeck.OutputDeck();  // Call method to output deck

                // display deck after creation
                Console.WriteLine("\nThe deck after creation.");
                testDeck.OutputDeck();  // Call method to output deck
            }
            else
            {
                Console.WriteLine("\nUnexpected input...no deck created.");
            }
            // End program
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);

        }
    }
}