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
        public Hand playerHand = new Hand();         //Player "hand" of pictureBoxCards
        public Card cityCard;                        //Player city card
        public Deck playerDeck;                      //Player "hand" of pictureBoxCards
        private int _points;
        public bool moved = false;                

        
        /// <summary>
        /// Func checks if player have enough resources to play card
        /// </summary>
        /// <param name="card">Card to play</param>
        /// <returns>true if card can be played, false if not </returns>
        public bool CanBePlayed(Card card)
        {
            bool ifCan = false;
            if (card.ResOfCard <= resourceQuantity)
            {
                ifCan = true;
            }
            return ifCan;
        }

        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }
    }
}
