using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    public enum BoosterType
    {
        empty = 0,
        small = 3,
        big = 6
    }


    /// <summary>
    /// Shop Manager
    /// </summary>
    public class ShopManager
    {
        
        /// <summary>
        /// Gunc generates booster with random cards
        /// </summary>
        /// <param name="booster">Booster Type</param>
        /// <returns>Generated BoosterDeck</returns>
        public BoosterDeck GenerateBooster(BoosterType booster)
        {
            Random rnd = new Random();
            Deck all = _sql.GetDeck(SQLManager.ALL_CARDS_USER, SQLManager.ALL_CARDS_DECK);                      //Getting all cards from db
            List<Card> cardList = new List<Card>();

            for (int i = 0; i < (int)booster; i++)
            {
                cardList.Add(all.cardsInCollection[(Rand.GetRandInt(rnd, 0, all.cardsInCollection.Count))]);    //Adding cards to booster
            }

            return new BoosterDeck(booster, cardList); ;
        }

        /// <summary>
        /// Finc adds card to db
        /// </summary>
        /// <param name="deck">deck to add</param>
        /// <param name="plyr">player login</param>
        public void AddCards(Deck deck, Player plyr)
        {
            _sql.AddNewDeck(deck, plyr.playerName);
        }


        /// <summary>
        /// Func updates player points to db
        /// </summary>
        /// <param name="playerName">player login</param>
        /// <param name="pointsDelta">difference in points</param>
        public void UpdatePoints(string playerName, int pointsDelta)
        {
            _sql.UpdatePoints(playerName, pointsDelta);
        }


        private SQLManager _sql = new SQLManager();
    }
}
