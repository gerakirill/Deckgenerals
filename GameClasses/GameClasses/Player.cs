using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    public class Player
    {        
        public string playerName;                    //Player name
        public int resourceQuantity = 1;             //Number of player resources         
        public Hand playerHand;                      //Player "hand" of pictureBoxCards
        public Card cityCard;                        //Player city card
        public Deck playerDeck;                      //Player "hand" of pictureBoxCards
        public bool tookCard = false;                //If player took card this turn 


        /// <summary>
        /// Returns true if card can be played
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool CanBePlayed(Card card)
        {
            bool ifCan = false;
            if (card.ResOfCard <= resourceQuantity)
            {
                ifCan = true;
            }
            return ifCan;
        }
    }
}
