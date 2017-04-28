using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;



namespace GameClasses
{
    /// <summary>
    /// Card Types
    /// </summary>
    public enum CardTypes
    {
        empty = 0,
        city = 1,               //Card type City
        resource = 2,           //Card type Resource
        scene = 4,              //Card type Scene
        armor = 8,              //Card type Armor
        infantry = 16           //Card type Infarntry
    }

    /// <summary>
    /// Abiity type of pictureBoxCards
    /// </summary>
    [Flags]
    public enum AbilityTypes
    {
        empty = 0,
        dealDamage,             //Deals damage to opponent city
        buildCity,              //Build own city  
        addRes,                 //Add resource            
    }


    /// <summary>
    /// Card Rarity
    /// </summary>  
    public enum CardRarity
    {
        empty = 0,
        Common = 1,
        Rare = 2,
        Unique = 4,
        Legendary = 8
    }

    /// <summary>
    /// Class describes Deck
    /// </summary>
    public class Deck : CardsCollection, ICloneable
    {

        public Deck()
        {

        }

        public Deck(string nameOfDeck, List<Card> cardList)
        {
            deckName = nameOfDeck;
            foreach (Card card in cardList)
            {
                AddCard(card);
            }
        }


        public Deck(string nameOfDeck, List<Card> cardList, Card cityCard)
        {
            deckName = nameOfDeck;
            _cityCard = (Card)cityCard.Clone();
            foreach (Card card in cardList)
            {
                AddCard(card);
            }
        }
        
        /// <summary>
        /// Fanc adds card to deck with restrictions depending on card rarity
        /// </summary>
        /// <param name="card">Card to add</param>
        public void AddWithRestrictions(Card card)
        {
            CardTypes typeOfCard = card.TypeOfCard;  
            switch (typeOfCard)
            {
                case CardTypes.empty:
                    break;
                case CardTypes.city:
                    _cityCard = card;
                    break;
                case CardTypes.resource:
                    break;
                case CardTypes.scene:
                    break;
                case CardTypes.armor:
                    if (CanBeAdded(card))
                    {
                        _cards.Add(card);
                    }
                    break;
                case CardTypes.infantry:
                    if (CanBeAdded(card))
                    {
                        _cards.Add(card);
                    }
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Faunc checks if card can be added to deck. True if can, false if not
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool CanBeAdded(Card card)
        {
            bool result = true;
            int numberOfCardInDeck = 0;
            int maxNumber = 0;
            CardRarity rarityOfCard = card.RarityOfCard;
            switch (rarityOfCard)
            {
                case CardRarity.empty:
                    break;
                case CardRarity.Common:
                    maxNumber = COMMON_CARD_LIMIT;
                    break;
                case CardRarity.Rare:
                    maxNumber = RARE_CARD_LIMIT;
                    break;
                case CardRarity.Unique:
                    maxNumber = UNIQUE_CARD_LIMIT;
                    break;
                case CardRarity.Legendary:
                    maxNumber = LEGENDARY_CARD_LIMIT;
                    break;
                default:
                    break;
            }

            foreach (Card playerCard in cardsInCollection)
            {
                if (card.NameOfCard == playerCard.NameOfCard)
                {
                    numberOfCardInDeck++;
                }
            }
            if (numberOfCardInDeck >= maxNumber)
            {
                result = false;
            }

            return result;
        }
        

        /// <summary>
        /// Func changes Card indexes in Deck
        /// </summary>
        public void ShuffleDeck()
        {
            List<Card> shuffledDeckCards = _cards.OrderBy(c => Guid.NewGuid()).ToList();
            _cards = shuffledDeckCards;
        }

        public virtual object Clone()
        {
            Deck returnDeck;
            List<Card> newList = new List<Card>();
            foreach (Card card in this.cardsInCollection)
            {
                newList.Add((Card)card.Clone());
            }
            if (_cityCard != null)
            {
                returnDeck = new Deck(this.DeckName, newList, (Card)this._cityCard.Clone());
            }
            else
            {
                returnDeck = new Deck(this.DeckName, newList);
            }
            return returnDeck;
        }

        public Card CityCard
        {
            get
            {
                Card returnCard = null;
                if (_cityCard != null)
                {
                    returnCard = (Card)_cityCard.Clone();
                }
                return returnCard;
            }
            set
            {
                _cityCard = (Card)value.Clone();
            }
        }

        public string DeckName
        {
            get
            {
                return deckName;
            }
            set
            {
                deckName = value;
            }
        }
        
        private const int COMMON_CARD_LIMIT = 4;                //Card number in deck limit for Common cards
        private const int RARE_CARD_LIMIT = 3;                  //Card number in deck limit for Rare cards
        private const int UNIQUE_CARD_LIMIT = 2;                //Card number in deck limit for Unique cards
        private const int LEGENDARY_CARD_LIMIT = 1;             //Card number in deck limit for Legendary cards

        private string deckName;                                //Name of Deck
        private Card _cityCard;                                 //City card of deck
    }
}