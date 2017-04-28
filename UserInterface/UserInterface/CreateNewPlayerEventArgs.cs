using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class CreateNewPlayerEventArgs
    {
        public CreateNewPlayerEventArgs(string login, string pass, string email)
        {
            playerLogin = login;
            playerPassword = pass;
            playerEmail = email;
        }
        public string playerLogin { get; private set; }
        public string playerPassword { get; private set; }
        public string playerEmail { get; private set; }
    }
}
