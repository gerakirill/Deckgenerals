using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClasses;
using System.IO;

namespace UserInterface
{
    //Game pages
    public enum Pages
    {
        empty = 0,
        tabpg_mainmenu = 1,                 //Main menu page
        tabpg_register = 2,                 //Register new player page
        tabpg_loginmenu = 3,                //After authorisation page
        tabpg_selectdeck = 4                //Select deck page

    }

    public delegate void PlayerCreater(object sender, CreateNewPlayerEventArgs args);
    public delegate void LogIner(object sender, LogInPlayerEventArgs args);



    public partial class MainMenuInterface : Form
    {
        public MainMenuInterface()
        {
            InitializeComponent();
        }
        public MainMenuInterface(LoginManager lgnMngr)
        {
            _loginMngr = lgnMngr;
            InitializeComponent();
        }

        public event PlayerCreater CreateNewPlayerEvent;
        public event LogIner LogInPlayerEvent;
        public event EventHandler DeckClickEvent;
        public event Action QuitEvent;
        public event Action StartGameVSAIEvent;
        public event Action DeckManagerStartEvent;
        public event Action CreateNewDeckEvent;
        public event Action ShopStartEvent;

        /// <summary>
        /// Func sets active game page
        /// </summary>
        /// <param name="page"></param>
        public void SetActivePage(Pages page)
        {
            currentPage = page;
            tabControl1.SelectTab(currentPage.ToString());
        }

        /// <summary>
        /// Func shows message to player
        /// </summary>
        /// <param name="text">text to show</param>
        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        public void UserCreatedEventHandler()
        {
            MessageBox.Show("User created");
            currentPage = Pages.tabpg_mainmenu;
            SetActivePage(currentPage);
        }

        /// <summary>
        /// Func removes deck pictures from interface
        /// </summary>
        public void RemoveDecks()
        {
            foreach (DeckPictureBox pct in _pictureBoxDecks)
            {
                tabControl1.TabPages[Pages.tabpg_selectdeck.ToString()].Controls.Remove(pct);
            }
            foreach (Label lbl in _labels)
            {
                tabControl1.TabPages[Pages.tabpg_selectdeck.ToString()].Controls.Remove(lbl);
            }
            _pictureBoxDecks.Clear();
            _labels.Clear();
        }

        /// <summary>
        /// Func adds deck pictures to interface
        /// </summary>
        /// <param name="deckList">List of player decks to add</param>
        public void ShowDecks(List<Deck> deckList)
        {
            int windowWidth = this.Size.Width;
            int windowHeight = this.Size.Height;
            int cardImageWidth = 150;               //Setting card image size
            int cardImageHeight = 225;
            int indent = 5;                         //Setting inden between _cards
            int i = cardImageWidth + indent;
            int j = indent + 50;
            int iMax = windowWidth - cardImageWidth - indent;
            j = cardImageHeight - indent;
            iMax = windowWidth - 2 * cardImageWidth - indent;
            foreach (Deck deck in deckList)
            {
                DeckPictureBox picture = new DeckPictureBox(deck);
                picture.Size = new Size(cardImageWidth, cardImageHeight);
                picture.BorderStyle = BorderStyle.Fixed3D;
                picture.ImageLocation = "..\\..\\..\\..\\cards.img\\Shirt.jpg";
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                Label lbl_deckname = new Label();
                lbl_deckname.AutoSize = true;
                lbl_deckname.Text = deck.DeckName;
                lbl_deckname.BackColor = Color.Transparent;
                lbl_deckname.ForeColor = Color.DarkCyan;
                lbl_deckname.Font = new Font("Stencil", 10, FontStyle.Regular);
                lbl_deckname.Location = new Point(i, j);

                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Click += new EventHandler(deck_click);
                if (i < iMax)                                          //if exceedeing borders - start visualise from new line
                {
                    picture.Location = new Point(i, j);
                    this.tabControl1.TabPages[currentPage.ToString()].Controls.Add(lbl_deckname);
                    this.tabControl1.TabPages[currentPage.ToString()].Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                else
                {
                    i = cardImageWidth + indent;
                    j += cardImageHeight + indent;
                    picture.Location = new Point(i, j);
                    this.tabControl1.TabPages[currentPage.ToString()].Controls.Add(lbl_deckname);
                    this.tabControl1.TabPages[currentPage.ToString()].Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                _labels.Add(lbl_deckname);
                _pictureBoxDecks.Add(picture);
            }
        }


        #region Button click events 
        private void btn_quit_Click(object sender, EventArgs e)
        {
            if (QuitEvent != null)
            {
                QuitEvent();
            }
        }

        private void btn_quitmain_Click(object sender, EventArgs e)
        {
            if (QuitEvent != null)
            {
                QuitEvent();
            }
        }
      
        private void btn_about_Click(object sender, EventArgs e)
        {

        }
       
        private void btn_regproceed_Click(object sender, EventArgs e)
        {
            if (CreateNewPlayerEvent != null)
            {
                CreateNewPlayerEvent(this, new CreateNewPlayerEventArgs(txt_login.Text, txt_password.Text, txt_email.Text));
            }
        }

        private void btn_proceedmain_Click(object sender, EventArgs e)
        {
            if (LogInPlayerEvent != null)
            {
                LogInPlayerEvent(this, new LogInPlayerEventArgs(txt_loginmain.Text, txt_passmain.Text));
            }
        }

        private void btn_playvsai_Click(object sender, EventArgs e)
        {
            if (StartGameVSAIEvent != null)
            {
                StartGameVSAIEvent();
            }

        }

        private void btn_deckmanager_Click(object sender, EventArgs e)
        {
            if (DeckManagerStartEvent != null)
            {
                DeckManagerStartEvent();
            }
        }

        private void btn_newdeck_Click(object sender, EventArgs e)
        {
            if (CreateNewDeckEvent != null)
            {
                CreateNewDeckEvent();
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            currentPage = Pages.tabpg_register;
            SetActivePage(currentPage);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            txt_loginmain.Enabled = true;
            txt_loginmain.Visible = true;
            txt_passmain.Enabled = true;
            txt_passmain.Visible = true;
            lbl_passmain.Visible = true;
            lbl_passmain.Enabled = true;
            lbl_enternamemain.Visible = true;
            lbl_enternamemain.Enabled = true;
            btn_proceedmain.Visible = true;
            btn_proceedmain.Enabled = true;
        }

        private void btnReturnSelectDeck_Click(object sender, EventArgs e)
        {
            RemoveDecks();
            SetActivePage(Pages.tabpg_loginmenu);
        }

        private void btn_shop_Click(object sender, EventArgs e)
        {
            if (ShopStartEvent != null)
            {
                ShopStartEvent();
            }
        }

        private void deck_click(object sender, EventArgs e)
        {
            if (DeckClickEvent != null)
            {
                DeckClickEvent(sender, new EventArgs());
            }
        }
        #endregion
        
        private List<Label> _labels = new List<Label>(0);
        private List<DeckPictureBox> _pictureBoxDecks = new List<DeckPictureBox>(0);
        private  LoginManager _loginMngr;
        private Pages currentPage = Pages.tabpg_mainmenu;
        
    }
}
