using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClasses;

namespace DeckGenerals
{
    class MyPictureBox : PictureBox
    {
        public MyPictureBox(Card card)
        {
            _card = (Card)card.Clone();
        }

        public Card _card;
    }
}
