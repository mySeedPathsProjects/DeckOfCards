using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }
    }


    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
	//     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
	//     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
	//     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
	//         discard pile	
    // 
    // A deck knows the following information about itself:
	//     int CardsRemaining -- number of cards left in the deck
	//     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played


    /// <summary>
    /// Deck of 52 Playing Cards
    /// </summary>
    class Deck
    {
        //Declare Properties
        public int CardsRemaining { get; set; }
        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }

        /// <summary>
        /// CONSTRUCTOR: Creates a deck of 52 playing cards
        /// </summary>
        public Deck()
        {
            //initialize Properties
            this.CardsRemaining = 0;
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();
            //initialize DeckOfCards with 52 unique cards of each Rank and Suit
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 2; j <= 14; j++)
                {
                    this.DeckOfCards.Add(new Card((Rank)j, (Suit)i));
                }
            }
        }

        /// <summary>
        /// CONSTRUCTOR: Creates a deck of (52 * numberOfDecks) cards
        /// </summary>
        /// <param name="numberOfDecks">number of decks</param>
        public Deck(int numberOfDecks)
        {
            //initialize Properties
            this.CardsRemaining = 0;
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();
            //initialize DeckOfCards with 52 unique cards of each Rank and Suit for (numberOfDecks) times
            for (int n = 0; n < numberOfDecks; n++)
            {
                for (int i = 1; i <= 4; i++)
                {
                    for (int j = 2; j <= 14; j++)
                    {
                        this.DeckOfCards.Add(new Card((Rank)j, (Suit)i));
                    }
                }
            }
        }

        /// <summary>
        /// Rearrange Cards in the DeckOfCards at random
        /// </summary>
        public void Shuffle()
        {
            //add DiscardedCards pile to the DeckOfCards deck
            this.DeckOfCards.AddRange(DiscardedCards);
            //clear all cards from the DiscardedCards pile
            this.DiscardedCards.Clear();
            //create a random number generator
            Random rng = new Random();
            //grab a random card from the DeckOfCards, remove it, and add it to the front of the deck.  Continue until all cards have been placed in a new random position
            for (int i = 0; i < this.DeckOfCards.Count; i++)
            {
                int randomIndex = rng.Next(i, this.DeckOfCards.Count);
                this.DeckOfCards.Insert(i, this.DeckOfCards[randomIndex]);
                this.DeckOfCards.RemoveAt(randomIndex + 1);
            }
        }

        /// <summary>
        /// Returns a List of Cards based on number requested
        /// </summary>
        /// <param name="numberOfCards">number of cards requested</param>
        /// <returns>List of Cards</returns>
        public List<Card> Deal(int numberOfCards)
        {
            //temporary List to hold number of Cards requested
            List<Card> dealtCards = this.DeckOfCards.Take(numberOfCards).ToList();
            //remove the requested cards from original deck
            this.DeckOfCards.RemoveRange(0, 5);
            return dealtCards;
        }

        /// <summary>
        /// Adds discarded card to the DiscardedCards deck
        /// </summary>
        /// <param name="card">Card to discard</param>
        public void Discard(Card card)
        {
            this.DiscardedCards.Add(card);
        }

        /// <summary>
        /// Adds discarded cards to the DiscardedCards deck
        /// </summary>
        /// <param name="cards">List of Cards to discard</param>
        public void Discard(List<Card> cards)
        {
            this.DiscardedCards.AddRange(cards);
        }
    }


    public enum Suit
    {
        Hearts = 1,
        Diamonds,
        Clubs,
        Spades
    }
    public enum Rank
    {
        Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }

    // What makes a card?
	//     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"
    class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }
    }
}
