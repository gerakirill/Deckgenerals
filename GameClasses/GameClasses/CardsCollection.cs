using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    /// <summary>
    /// Base class for any class, containing card collection
    /// </summary>
    public class CardsCollection : IEnumerable
    {
        
        /// <summary>
        /// Func adds card to collection
        /// </summary>
        /// <param name="card"></param>
        public virtual void AddCard(Card card)
        {
            if (card != null)
            {
                _cards.Add((Card)card.Clone());
            }    
        }
        /// <summary>
        /// Func returns card to remove and removes it from collection
        /// </summary>
        /// <returns></returns>
        public Card GiveCard()
        {
            Card cardToGive = null;
            if (_cards.Count > 0)
            {
                cardToGive = (Card)_cards[_cards.Count - 1].Clone();
                _cards.RemoveAt(_cards.Count - 1);                
            }            
            return cardToGive;
        }

        /// <summary>
        /// Func removes first entry of card in collection
        /// </summary>
        /// <param name="card">Card to remove</param>
        public void RemoveCard(Card card)
        {
            int index = _cards.BinarySearch(card);
            _cards.RemoveAt(index);           
        }
        
        public List<Card> cardsInCollection
        {
            get
            {
                List<Card> newList = new List<Card>(_cards.Count);
                for (int i = 0; i < _cards.Count; i++)
                {
                    if (_cards[i]!=null)
                    {
                        newList.Add((Card)_cards[i].Clone());
                    }                    
                }
                return newList;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return cardsInCollection.GetEnumerator();
        }

        protected List<Card> _cards = new List<Card>(0);    //Array of Cards in collection
    }
}

