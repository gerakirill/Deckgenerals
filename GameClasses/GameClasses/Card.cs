using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;


namespace GameClasses
{
    /// <summary>
    /// Class Card
    /// </summary>
    public class Card : ICloneable, IComparable<Card>
    {
        /// <summary>
        /// Class Card ctor
        /// </summary>
        /// <param name="name"></param>             //Card name
        /// <param name="type"></param>             //Card type
        /// <param name="ability"></param>          //Card ability
        /// <param name="resourceReq"></param>      //Card resouce requirement
        /// <param name="abilityValue"></param>     //Card ability value
        /// <param name="abilityText"></param>      //Text of cad ability
        /// <param name="image"></param>            //Visual of card
        /// <param name="attackValue"></param>      //Attack value of card
        /// <param name="strengthValue"></param>    //Stength value of card
        /// /// <param name="rarity"></param>       //Rarity of card
        public Card(string name, CardTypes type, AbilityTypes ability, int resourceReq, int abilityValue, string abilityText, Image image, int attackValue, int strengthValue, CardRarity rarity)
        {
            _cardType = type;
            _cardName = name;
            _cardResourceReq = resourceReq;
            _cardAbility = ability;
            _cardAbilityValue = abilityValue;
            _cardAbilityText = abilityText;
            _cardImage = image;
            _cardStrength = strengthValue;
            _cardAttack = attackValue;
            _rarity = rarity;
        }
        public Card()
        {
        }        
        public object Clone()
        {
            return new Card(this._cardName, this._cardType, this._cardAbility, this._cardResourceReq, this._cardAbilityValue, this._cardAbilityText, this._cardImage, this._cardAttack, this._cardStrength, this._rarity);
        }

        /// <summary>
        /// Sort order of cards in Hand
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Card obj)
        {
            if (this._cardResourceReq > obj._cardResourceReq)
            {
                return 1;
            }
            if (this._cardResourceReq < obj._cardResourceReq)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Func changes card Strength
        /// </summary>
        /// <param name="delta"></param>
        public void ChangeCardStrength(int delta)
        {
            _cardStrength += delta;
        }

        public Image VisualOfCard
        {
            get { return _cardImage; }
        }

        public CardTypes TypeOfCard
        {
            get { return _cardType; }
        }

        public AbilityTypes AbilityOfCard
        {
            get { return _cardAbility; }
        }

        public int ResOfCard
        {
            get { return _cardResourceReq; }
        }

        public string AbilityTextOfCard
        {
            get { return _cardAbilityText; }
        }

        public int AbilityValOfCard
        {
            get { return _cardAbilityValue; }
        }

        public string NameOfCard
        {
            get { return _cardName; }
        }

        public int StrengthOfCard
        {
            get { return _cardStrength; }
        }

        public int AttackOfCard
        {
            get { return _cardAttack; }
        }

        private CardTypes _cardType;              //card type
        private string _cardName;                 //card name
        private int _cardResourceReq;             //resource reqiurement for playing card
        private AbilityTypes _cardAbility;        //special ability of card
        private int _cardAbilityValue;            //card ability value
        private string _cardAbilityText;          //text represntation of card ability
        private Image _cardImage;                 //text represntation of card ability
        private int _cardAttack;                  //attack value of card
        private int _cardStrength;                //strength value of card
        private CardRarity _rarity;               //rarity of card


    }
}
