using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClasses;
using System.IO;
using System.Drawing;


namespace UserInterface
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginManager mng = new LoginManager();            
            UserInterface user = new UserInterface();
            LoginController cntrl = new LoginController(user, mng);           
            //Controller cntrl1 = new Controller(user, mng);
            Application.Run(user);

        }
    }
}
