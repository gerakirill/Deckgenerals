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


    public class Deck : CardsCollection, IEnumerable
    {
        /// <summary>
        /// Func fillse the deck with cards of specific card type
        /// </summary>
        /// <param name="deckType">type of card to fill deck</param>
        /// <param name="allcards">List of all cards</param>
        public void FillDeck(string deckType, List<Card> allcards)
        {
            foreach (Card card in allcards)
            {
                CardTypes typeOfCard = card.TypeOfCard;
                AbilityTypes abilityOfCard = card.AbilityOfCard;
                switch (deckType)
                {
                    case "city":
                        if (typeOfCard == CardTypes.city)
                        {
                            cards.Add(card);
                            break;
                        }
                        continue;
                    case "scene":
                        if (typeOfCard == CardTypes.scene)
                        {
                            cards.Add(card);
                            break;
                        }
                        continue;
                    case "playerdeck":
                        if (!(typeOfCard == CardTypes.city) | typeOfCard == CardTypes.scene)
                        {
                            cards.Add(card);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Func adds a card to players deck
        /// </summary>
        /// <param name="chosenCard"></param>
        public void FillPlayersDeck(Card chosenCard)
        {
            cards.Add((Card)chosenCard.Clone());
        }
        public IEnumerator GetEnumerator()
        {
            return cardsInCollection.GetEnumerator();
        }
        

        /// <summary>
        /// Func changes Card indexes in Deck
        /// </summary>
        public void ShuffleDeck()
        {
            Random rnd = new Random();
            for (int i = cards.Count - 1; i >= 1; i--)    //Fisher–Yates shuffle
            {
                int j = rnd.Next(i + 1);
                Card temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }
    }
}
