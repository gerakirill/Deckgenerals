using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{


    public class Field
    {
        public Field()
        {
            armorCardStrength = 0;
            infantryCardStrength = 0;
            armorOccupiedByPlayer = null;
            infantryOccupiedByPlayer = null;
        }
        public int armorCardStrength { get; private set; }
        public int infantryCardStrength { get; private set; }
        public string armorOccupiedByPlayer { get; private set; }
        public string infantryOccupiedByPlayer { get; private set; }


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
                case CardTypes.material:
                    break;
                case CardTypes.infantry:
                    PerformAction(card, playerName);
                    break;
                default:
                    break;
            }

        }

        private void PerformAction(Card card, string playerName)
        {
            Card cardToAct = new Card();
            string cardOccupied;
            if (card.TypeOfCard.HasFlag(CardTypes.armor))
            {
                cardToAct = _armorCard;
                cardOccupied = armorOccupiedByPlayer;
            }
            else
            {
                cardToAct = _infantryCard;
                cardOccupied = infantryOccupiedByPlayer;
            }
            if (cardToAct != null)
            {
                if (playerName == cardOccupied)
                {
                    cardToAct = card;
                }
                else
                {
                    if (card.AttackOfCard > cardToAct.StrengthOfCard)
                    {
                        cardToAct = card;
                        cardOccupied = playerName;
                    }
                    else
                    {
                        if (card.AttackOfCard < cardToAct.StrengthOfCard)
                        {
                            cardToAct.ChangeCardStrength(-card.AttackOfCard);
                        }
                        else
                        {
                            cardToAct = null;
                            cardOccupied = null;
                        }
                    }
                }
            }
            else
            {
                cardToAct = card;
                cardOccupied = playerName;
            }

            if (card.TypeOfCard.HasFlag(CardTypes.armor))
            {
                _armorCard = cardToAct;
                armorOccupiedByPlayer = cardOccupied;
            }
            else
            {
                _infantryCard = cardToAct;
                infantryOccupiedByPlayer = cardOccupied;
            }
        }

        private Card _armorCard = null;
        private Card _infantryCard = null;

    }
}
