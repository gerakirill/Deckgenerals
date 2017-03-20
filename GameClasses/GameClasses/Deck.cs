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
    [Flags]
    public enum CardTypes
    {
        empty = 0,
        city = 1,       //Card type Tower
        resource = 2,    //Card type Resource
        scene = 4,       //Card type Scene
        armor = 8,      //Card type Weapon
        material = 16,    //Card type Material
        infantry = 32       //Card type Chance
    }

    /// <summary>
    /// Abiity type of pictureBoxCards
    /// </summary>
    [Flags]
    public enum AbilityTypes
    {
        empty = 0,
        dealDamage,    //Deals damage to opponent city
        buildCity,    //Build own city  
        addRes,        //Add resource            
    }

    /// <summary>
    /// Class "Deck"  
    /// </summary>
    public class Deck : Hand, IEnumerable
    {
        /// <summary>
        /// Func takes deck type and array of all of the pictureBoxCards. Fills deck of specific type with pictureBoxCards
        /// </summary>
        /// <param name="deckType">Type of deck to fill</param>
        /// <param name="allcards">Array of all pictureBoxCards in game</param>
        public void FillDeck(string deckType, List<Card> allcards)
        {
            foreach (Card card in allcards)
            {
                CardTypes typeOfCard = card.TypeOfCard;
                AbilityTypes abilityOfCard = card.AbilityOfCard;
                switch (deckType)
                {
                    case "city":
                        if (typeOfCard.HasFlag(CardTypes.city))
                        {
                            cards.Add(card);
                            break;
                        }
                        continue;
                    case "scene":
                        if (typeOfCard.HasFlag(CardTypes.scene))
                        {
                            cards.Add(card);
                            break;
                        }
                        continue;
                    case "playerdeck":
                        if (!(typeOfCard.HasFlag(CardTypes.city) | typeOfCard.HasFlag(CardTypes.scene)))
                        {
                            cards.Add(card);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public void FillPlayersDeck(Card chosenCard)
        {
            int copiesInDeck = 4;
            for (int i = 0; i < copiesInDeck; i++)
            {
                cards.Add((Card)chosenCard.Clone());
            }
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

        /// <summary>
        /// Func creates and sets every Card in game 
        /// </summary>
        public List<Card> CreateCards()
        {
            List<Card> allcards = new List<Card>();    //Array of all card           

            //NEW CARD      
            Image stalingradImage = Image.FromFile("C:\\C#\\DeckGenerals\\cards.img\\Stalingrad.jpg");
            Card stalingrad = new Card("Stalingrad", CardTypes.city, AbilityTypes.empty, 0, 12, "Every time you build a city get 1 res.", stalingradImage, 0, 0);    //Creating card           
            allcards.Add(stalingrad);    //adding card to array

            //NEW CARD      
            Image moscowImage = Image.FromFile("C:\\C#\\DeckGenerals\\cards.img\\Moscow.jpg");
            Card moscow = new Card("Moscow", CardTypes.city, AbilityTypes.empty, 0, 12, "Every time you build a city get 1 res.", moscowImage, 0, 0);    //Creating card           
            allcards.Add(moscow);    //adding card to array

            //NEW CARD      
            Image leningradImage = Image.FromFile("C:\\C#\\DeckGenerals\\cards.img\\Leningrad.jpg");
            Card leningrad = new Card("Leningrad", CardTypes.city, AbilityTypes.empty, 0, 12, "Every time you build a city get 1 res.", leningradImage, 0, 0);    //Creating card           
            allcards.Add(leningrad);    //adding card to array

            //NEW CARD      
            Image ba1Image = Image.FromFile("C:\\C#\\DeckGenerals\\cards.img\\BA10.jpg");
            Card ba1 = new Card("BA1", CardTypes.armor, AbilityTypes.empty, 1, 1, "Every time you build a city get 1 res.", ba1Image, 1, 1);    //Creating card           
            allcards.Add(ba1);    //adding card to array

            //NEW CARD      
            Image T26Image = Image.FromFile("C:\\C#\\DeckGenerals\\cards.img\\T26.jpg");
            Card T26 = new Card("T26", CardTypes.armor, AbilityTypes.empty, 2, 2, "Every time you build a city get 1 res.", T26Image, 1, 2);    //Creating card           
            allcards.Add(T26);    //adding card to array

            //NEW CARD      
            Image T28Image = Image.FromFile("C:\\C#\\DeckGenerals\\cards.img\\T28.jpg");
            Card T28 = new Card("T28", CardTypes.armor, AbilityTypes.empty, 3, 2, "Every time you build a city get 1 res.", T28Image, 2, 2);    //Creating card           
            allcards.Add(T28);    //adding card to array

            //NEW CARD      
            Image BT2Image = Image.FromFile("C:\\C#\\DeckGenerals\\cards.img\\BT2.jpg");
            Card BT2 = new Card("BT2", CardTypes.armor, AbilityTypes.empty, 2, 2, "Every time you build a city get 1 res.", BT2Image, 2, 1);    //Creating card           
            allcards.Add(BT2);    //adding card to array

            //NEW CARD      
            Image ParatroopersImage = Image.FromFile("C:\\C#\\DeckGenerals\\cards.img\\Paratroopers.jpg");
            Card VDV = new Card("Paratroopers", CardTypes.infantry, AbilityTypes.empty, 2, 2, "Every time you build a city get 1 res.", ParatroopersImage, 1, 2);    //Creating card           
            allcards.Add(VDV);    //adding card to array


            //NEW CARD            

            return allcards;

        }


    }
}
