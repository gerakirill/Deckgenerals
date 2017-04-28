using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    /// <summary>
    /// Class describes booster in shop
    /// </summary>
    public class BoosterDeck : Deck, ICloneable
    {
        public BoosterDeck(BoosterType bType, List<Card> cards) : base(bType.ToString(), cards)
        {
            _bType = bType;
            SetPointsCost(bType);
        }
        /// <summary>
        /// Setting points cost of booster
        /// </summary>
        /// <param name="bType"></param>
        private void SetPointsCost(BoosterType bType)
        {
            switch (bType)
            {
                case BoosterType.empty:
                    break;
                case BoosterType.small:
                    _pointsCost = SMALL_BOOSTER_COST;
                    break;
                case BoosterType.big:
                    _pointsCost = BIG_BOOSTER_COST;
                    break;
                default:
                    break;
            }
        }

        public int PointsCost
        {
            get
            {
                return _pointsCost;
            }
        }

        public BoosterType BType
        {
            get
            {
                return _bType;
            }
        }


        public BoosterDeck Booster
        {
            get
            {
                return (BoosterDeck)this.Clone();
            }
        }
        

        public override object Clone()
        {
            List<Card> newList = new List<Card>();
            foreach (Card card in this.cardsInCollection)
            {
                newList.Add((Card)card.Clone());
            }            
            return new BoosterDeck(this._bType, newList);
        }

        private int _pointsCost;                        //How much points this booster cost
        private BoosterType _bType;                     //Type of booster

        private const int SMALL_BOOSTER_COST = 30;
        private const int BIG_BOOSTER_COST = 50;

    }
}
