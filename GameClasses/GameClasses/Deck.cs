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
        city = 1,               //Card type City
        resource = 2,           //Card type Resource
        scene = 4,              //Card type Scene
        armor = 8,              //Card type Armor
        material = 16,          //Card type Material
        infantry = 32           //Card type Infarntry
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
                        if (typeOfCard.HasFlag(CardTypes.scene))
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

        /// <summary>
        /// Func creates and sets every Card in game 
        /// </summary>
        public List<Card> CreateCards()
        {
            List<Card> allcards = new List<Card>();    //Array of all card           

            //NEW CARD      
            Image stalingradImage = Image.FromFile(@"..\..\..\cards.img\Stalingrad.jpg");
            Card stalingrad = new Card("Stalingrad", CardTypes.city, AbilityTypes.empty, 0, 0, "", stalingradImage, 0, 12);    //Creating card           
            allcards.Add(stalingrad);    //adding card to array

            //NEW CARD      
            Image moscowImage = Image.FromFile(@"..\..\..\cards.img\Moscow.jpg");
            Card moscow = new Card("Moscow", CardTypes.city, AbilityTypes.empty, 0, 0, "", moscowImage, 0, 12);    //Creating card           
            allcards.Add(moscow);    //adding card to array

            //NEW CARD      
            Image leningradImage = Image.FromFile(@"..\..\..\cards.img\Leningrad.jpg");
            Card leningrad = new Card("Leningrad", CardTypes.city, AbilityTypes.empty, 0, 0, "", leningradImage, 0, 12);    //Creating card           
            allcards.Add(leningrad);    //adding card to array

            //NEW CARD      
            Image ba1Image = Image.FromFile(@"..\..\..\cards.img\BA10.jpg");
            Card ba1 = new Card("BA1", CardTypes.armor, AbilityTypes.empty, 1, 1, "", ba1Image, 1, 1);    //Creating card           
            allcards.Add(ba1);    //adding card to array

            //NEW CARD      
            Image T26Image = Image.FromFile(@"..\..\..\cards.img\T26.jpg");
            Card T26 = new Card("T26", CardTypes.armor, AbilityTypes.empty, 2, 2, "", T26Image, 1, 2);    //Creating card           
            allcards.Add(T26);    //adding card to array

            //NEW CARD      
            Image T28Image = Image.FromFile(@"..\..\..\cards.img\T28.jpg");
            Card T28 = new Card("T28", CardTypes.armor, AbilityTypes.empty, 3, 2, "", T28Image, 2, 2);    //Creating card           
            allcards.Add(T28);    //adding card to array

            //NEW CARD      
            Image BT2Image = Image.FromFile(@"..\..\..\cards.img\BT2.jpg");
            Card BT2 = new Card("BT2", CardTypes.armor, AbilityTypes.empty, 2, 2, "", BT2Image, 2, 1);    //Creating card           
            allcards.Add(BT2);    //adding card to array

            //NEW CARD      
            Image ParatroopersImage = Image.FromFile(@"..\..\..\cards.img\Paratroopers.jpg");
            Card VDV = new Card("Paratroopers", CardTypes.infantry, AbilityTypes.empty, 2, 2, "", ParatroopersImage, 1, 2);    //Creating card           
            allcards.Add(VDV);    //adding card to array
            
            return allcards;

        }


    }
}
