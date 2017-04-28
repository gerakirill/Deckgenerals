using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class LogInPlayerEventArgs
    {
        public LogInPlayerEventArgs(string login, string pass)
        {
            playerLogin = login;
            playerPassword = pass;
        }
        public string playerLogin { get; private set; }
        public string playerPassword { get; private set; }

    }
}
