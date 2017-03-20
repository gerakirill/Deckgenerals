using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GameClasses
{
    /// <summary>
    /// Class Hand
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// Func adds card to hand
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            cards.Add(card);
            cards.Sort();
        }
        public void AddCardFromDeck(ref Deck deckName)
        {
            cards.Add(deckName.GiveCard());
            cards.Sort();
        }
        public Card GiveCard()
        {
            Card cardToGive = (Card)cards[cards.Count - 1].Clone();
            cards.RemoveAt(cards.Count - 1);
            return cardToGive;
        }
        public void RemoveCard(Card card)
        {
            int index = cards.BinarySearch(card);
            cards.RemoveAt(index);
        }
        public int numberOfCards
        {
            get { return cards.Count; }
        }

        public List<Card> cardsInCollection
        {
            get
            {
                List<Card> newList = new List<Card>(cards.Count);
                for (int i = 0; i < cards.Count; i++)
                {
                    newList.Add((Card)cards[i].Clone());
                }
                return newList;
            }
        }
        protected List<Card> cards = new List<Card>(0);    //Array of pictureBoxCards in hand
    }
}
