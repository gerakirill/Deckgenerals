using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    public class CardPlayedEventArgs
    {
        public CardPlayedEventArgs(string playerPlayed, Card cardPlayed)
        {
            card = (Card)cardPlayed.Clone();
            playerName = playerPlayed;
        }
        public Card card;
        public string playerName;
    }
}
