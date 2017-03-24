using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClasses;
using System.IO;


namespace DeckGenerals
{

    public class Program
    {
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserInterface.UserInterface user = new UserInterface.UserInterface();
            Controller cntrl1 = new Controller(user);
            Application.Run(user);

        }
    }
}
