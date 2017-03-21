using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    public class CardsCollection
    {
        protected List<Card> cards = new List<Card>(0);    //Array of Cards in hand

        /// <summary>
        /// Func adds card to collection
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            cards.Add(card);
            cards.Sort();
        }
        /// <summary>
        /// Func returns card to remove and removes it from collection
        /// </summary>
        /// <returns></returns>
        public Card GiveCard()
        {
            Card cardToGive = (Card)cards[cards.Count - 1].Clone();
            cards.RemoveAt(cards.Count - 1);
            return cardToGive;
        }

        /// <summary>
        /// Func removes first entry of card in collection
        /// </summary>
        /// <param name="card">Card to remove</param>
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
    }
}
