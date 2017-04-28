using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClasses;

namespace UserInterface
{
    public class DeckPictureBox : PictureBox
    {
        public DeckPictureBox(Deck deck)
        {
            _deck = (Deck)deck.Clone();
        }

        public Deck Deck
        {
            get
            {
                return (Deck)_deck.Clone();
            }
        }

        protected Deck _deck;
    }
}
