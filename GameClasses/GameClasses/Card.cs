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
        /// Struct card ctor
        /// </summary>
        /// <param name="name">Card name</param>
        /// <param name="type">Card type</param>
        /// <param name="ability">Card ability</param>
        /// <param name="resourceReq">Resource requirement for card</param>
        /// <param name="abilityValue">Card ability value</param>
        /// <param name="abilityText">Card ability text</param>
        public Card(string name, CardTypes type, AbilityTypes ability, int resourceReq, int abilityValue, string abilityText, Image image, int attackValue, int strengthValue)
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
        }
        public Card()
        {
        }


        public object Clone()
        {
            return new Card(this._cardName, this._cardType, this._cardAbility, this._cardResourceReq, this._cardAbilityValue, this._cardAbilityText, this._cardImage, this._cardAttack, this._cardStrength);
        }

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
        private int _cardAttack;
        private int _cardStrength;


    }
}
