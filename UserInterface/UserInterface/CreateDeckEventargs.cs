using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public delegate void NewDeckCreater(object sender, CreateDeckEventargs e);
    public class CreateDeckEventargs
    {
        public CreateDeckEventargs(string deckName)
        {
            _deckName = deckName;
        }

        public string NameOfDeck
        {
            get
            {
                return _deckName;
            }
        }

        private string _deckName;
    }
}
