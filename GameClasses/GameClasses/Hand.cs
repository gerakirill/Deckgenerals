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
    public class Hand : CardsCollection
    {
        /// <summary>
        /// Func adds Card from deck
        /// </summary>
        /// <param name="deckName">Name of deck, from which to add card</param>
        public void AddCardFromDeck(Deck deckName)
        {
            Card cardToAdd = deckName.GiveCard();
            if (cardToAdd != null)
            {
                AddCard(cardToAdd);
            }            
            _cards.Sort();
        }
    }
}
