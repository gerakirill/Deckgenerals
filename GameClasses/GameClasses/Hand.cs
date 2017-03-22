using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GameClasses
{

    public class Hand : CardsCollection
    {
        public void AddCardFromDeck(ref Deck deckName)
        {
            Card cardToAdd = deckName.GiveCard();
            if (cardToAdd != null)
            {
                cards.Add(deckName.GiveCard());
            }            
            cards.Sort();
        }
    }
}
