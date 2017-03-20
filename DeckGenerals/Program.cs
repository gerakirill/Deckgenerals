using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClasses;


namespace DeckGenerals
{

    public class Program
    {
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserInterface user = new UserInterface();
            Controller cntrl1 = new Controller(user);
            Application.Run(user);

        }
    }
}
