using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    /// <summary>
    /// Class describes Game field
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Class field ctor
        /// </summary>
        public Field()
        {
            armorCardStrength = 0;
            infantryCardStrength = 0;
            armorOccupiedByPlayer = null;
            infantryOccupiedByPlayer = null;
        }
        public int armorCardStrength { get; private set; }              //Strength of armor card in field
        public int infantryCardStrength { get; private set; }           //Strength of infantry card in field
        public string armorOccupiedByPlayer { get; private set; }       //Armor card filed owns to player
        public string infantryOccupiedByPlayer { get; private set; }    //Infantry card filed owns to player




        /// <summary>
        /// Func gets the type of played card and chooses an action
        /// </summary>
        /// <param name="card">Card that was played</param>
        /// <param name="playerName">Name of player that played card</param>
        public void CardPlayed(Card card, string playerName)
        {
            switch (card.TypeOfCard)
            {
                case CardTypes.empty:
                    break;
                case CardTypes.city:
                    break;
                case CardTypes.resource:
                    break;
                case CardTypes.scene:
                    break;
                case CardTypes.armor:
                    PerformAction(card, playerName);
                    break;
                case CardTypes.infantry:
                    PerformAction(card, playerName);
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// Func sets the changes on the field  due to played card 
        /// </summary>
        /// <param name="card">Card that was played</param>
        /// <param name="playerName">Name of player that played card</param>

        private void PerformAction(Card card, string playerName)
        {
            Card cardToAct = new Card();
            string cardOccupied;
            if (card.TypeOfCard == CardTypes.armor)             //Discovering what type of card is played 
            {
                cardToAct = _armorCard;                         //Setting on what field will this card act
                cardOccupied = armorOccupiedByPlayer;
            }
            else
            {
                cardToAct = _infantryCard;                      //Setting on what field will this card act
                cardOccupied = infantryOccupiedByPlayer;
            }
            if (cardToAct != null)                              
            {
                if (playerName == cardOccupied)                //If field belongs to the player, which played card then changing the card in field
                {
                    cardToAct = card;
                }
                else                                           //Else - calculating damage dealt to card in field
                {
                    if (card.AttackOfCard > cardToAct.StrengthOfCard)       //IF attack of played card is bigger then strength of card in field 
                    {                                                       //setting played cad to the field
                        cardToAct = card;
                        cardOccupied = playerName;
                    }
                    else
                    {
                        if (card.AttackOfCard < cardToAct.StrengthOfCard)   //If attack of played card is less then strength of card in field 
                        {                                                   //substract card attack value from the cad in field
                            cardToAct.ChangeCardStrength(-card.AttackOfCard);
                        }
                        else
                        {
                            cardToAct = null;                               //If attack of played card is even with the strength of card in field
                            cardOccupied = null;                            //Setting field value to null
                        }
                    }
                }
            }
            else
            {                                                   //If field is empty setting played card to the field
                cardToAct = card;
                cardOccupied = playerName;
            }

            if (card.TypeOfCard == CardTypes.armor)
            {
                _armorCard = cardToAct;
                armorOccupiedByPlayer = cardOccupied;
            }
            else
            {
                _infantryCard = cardToAct;
                infantryOccupiedByPlayer = cardOccupied;
            }

            FieldChangedEvent(this, new EventArgs());             //Field changed event
        }

        public Card GetArmorCard()
        {
            Card returnCard = new Card();
            if (_armorCard != null)
            {
                returnCard = (Card)_armorCard.Clone();
            }
            return returnCard;
        }

        public Card GetInfantryCard()
        {
            Card returnCard = new Card();
            if (_infantryCard != null)
            {
                returnCard = (Card)_infantryCard.Clone();
            }
            return returnCard;
        }

        public EventHandler FieldChangedEvent;

        private Card _armorCard = null;         //Card in armor field
        private Card _infantryCard = null;      //Card in infantry field

    }
}
