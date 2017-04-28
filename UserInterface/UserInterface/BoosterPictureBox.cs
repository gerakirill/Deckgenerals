using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClasses;
using System.Windows.Forms;

namespace UserInterface
{

    public class BoosterPictureBox : PictureBox
    {
        public BoosterPictureBox(BoosterDeck deck)
        {
            boosterDeck = deck;
          
        }

        public BoosterDeck boosterDeck;
    }
}
