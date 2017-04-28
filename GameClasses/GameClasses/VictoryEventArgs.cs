using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    public class VictoryEventArgs
    {
        public VictoryEventArgs(string whoWon)
        {
            _whoWon = whoWon;
        }
        public string _whoWon { get; private set; }
    }
}
