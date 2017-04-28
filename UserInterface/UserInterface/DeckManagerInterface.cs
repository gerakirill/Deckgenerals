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

namespace UserInterface
{
  

    /// <summary>
    /// Deck manager interface
    /// </summary>
    public partial class DeckManagerInterface : Form
    {
        
        public DeckManagerInterface()
        {
            InitializeComponent();
        }

        public event EventHandler PictureClickEvent;
        public event EventHandler DeleteDeckEvent;
        public event Action CreateNewDeckEvent;
        public event Action CancelNewDeckEvent;
        public event Action ReturnEvent;
        public event NewDeckCreater SubmitNewDeckEvent;


        /// <summary>
        /// Func changes menu buttons visibility and condition
        /// </summary>
        public void ButtonChange()
        {
            if (this.btn_deckreturn.Visible)
            {
                this.btn_deckreturn.Visible = false;
                this.btn_deckreturn.Enabled = false;
                this.btn_newdeck.Visible = false;
                this.btn_newdeck.Enabled = false;
                this.chbox_deletedeck.Visible = false;
                this.chbox_deletedeck.Enabled = false;
                

                this.btn_submit.Visible = true;
                this.btn_submit.Enabled = true;
                this.btn_cancel.Visible = true;
                this.btn_cancel.Enabled = true;
                this.txt_deckname.Visible = true;
                this.txt_deckname.Enabled = true;
                this.lbl_deckname.Visible = true;
                this.lbl_deckname.Enabled = true;

                this.lstview_pickedCards.Enabled = true;
                this.lstview_pickedCards.Visible = true;
                this.lstview_pickedCards.Clear();
            }

            else
            {
                this.btn_deckreturn.Visible = true;
                this.btn_deckreturn.Enabled = true;
                this.btn_newdeck.Visible = true;
                this.btn_newdeck.Enabled = true;
                this.chbox_deletedeck.Visible = true;
                this.chbox_deletedeck.Enabled = true;
                this.chbox_deletedeck.CheckState = CheckState.Unchecked;



                this.btn_submit.Visible = false;
                this.btn_submit.Enabled = false;
                this.btn_cancel.Visible = false;
                this.btn_cancel.Enabled = false;
                this.txt_deckname.Visible = false;
                this.txt_deckname.Enabled = false;
                this.lbl_deckname.Visible = false;
                this.lbl_deckname.Enabled = false;

                this.lstview_pickedCards.Enabled = false;
                this.lstview_pickedCards.Visible = false;
                this.lstview_pickedCards.Clear();
            }
        }


        /// <summary>
        /// Func removes deck pictures and labels from interface
        /// </summary>
        public void RemoveDeckPictures()
        {
            foreach (DeckPictureBox pct in _pictureDecks)
            {
                this.Controls.Remove(pct);
            }
            foreach (Label lbl in _deckTexts)
            {
                this.Controls.Remove(lbl);
            }
            _deckTexts.Clear();
            _pictureDecks.Clear();
        }

        /// <summary>
        /// Func removes cards from interface
        /// </summary>
        public void RemoveCardPictures()
        {
            foreach (MyPictureBox ctrl in _pictureCards)
            {
                this.Controls.Remove(ctrl);
            }
            _pictureCards.Clear();
        }

        /// <summary>
        /// Func removes one card fom interface
        /// </summary>
        /// <param name="pct">Card to remove</param>
        public void RemoveCard(MyPictureBox pct)
        {
            this.Controls.Remove(pct);
            _pictureCards.Remove(pct);
        }

        /// <summary>
        /// Func adds to interface controls cards in deck and shows them
        /// </summary>
        /// <param name="deck">Deck to show</param>
        public void ShowCards(Deck deck)
        {
            int windowWidth = this.Size.Width;
            int windowHeight = this.Size.Height;
            int cardImageWidth = 150;               //Setting card image size
            int cardImageHeight = 225;
            int indent = 5;                         //Setting inden between _cards
            int i = cardImageWidth + indent;
            int j = indent + 50;
            int iMax = windowWidth - cardImageWidth - indent;
            j = indent;
            iMax = windowWidth - 2 * cardImageWidth - indent;
            foreach (Card card in deck.cardsInCollection)
            {
                MyPictureBox picture = new MyPictureBox(card);
                picture.Size = new Size(cardImageWidth, cardImageHeight);
                picture.Image = card.VisualOfCard;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Click += new EventHandler(picture_Click);
                if (i < iMax)                                          //if exceedeing borders - start visualise from new line
                {
                    picture.Location = new Point(i, j);
                    this.Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                else
                {
                    i = cardImageWidth + indent;
                    j += cardImageHeight + indent;
                    picture.Location = new Point(i, j);
                    this.Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                _pictureCards.Add(picture);
            }
        }

        /// <summary>
        /// Func adds card to log 
        /// </summary>
        /// <param name="card">card to add</param>
        public void AddCardToList(Card card)
        {
            _imgList.Images.Add(card.NameOfCard, card.VisualOfCard);
            _imgList.ImageSize = new Size(40, 60);
            lstview_pickedCards.SmallImageList = _imgList;
            this.lstview_pickedCards.Items.Add(card.NameOfCard, card.NameOfCard);
        }

        /// <summary>
        /// Func shows message
        /// </summary>
        /// <param name="msg">message to show</param>
        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Func shows players decks
        /// </summary>
        /// <param name="deckList">List of deck to show</param>
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
                lbl_deckname.BackColor = Color.White;

                this.Controls.Add(lbl_deckname);
                _deckTexts.Add(lbl_deckname);
                _pictureDecks.Add(picture);
                //picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Click += new EventHandler(deck_click);
                if (i < iMax)                                          //if exceedeing borders - start visualise from new line
                {
                    picture.Location = new Point(i, j);
                    this.Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
                else
                {
                    i = cardImageWidth + indent;
                    j += cardImageHeight + indent;
                    picture.Location = new Point(i, j);
                    this.Controls.Add(picture);
                    i += cardImageWidth + indent;
                }
            }
        }

        #region Events
        private void picture_Click(object sender, EventArgs e)
        {
            MyPictureBox pct = sender as MyPictureBox;
            if (PictureClickEvent!=null)
            {
                PictureClickEvent(pct, new EventArgs() );
            }
        }

        
        private void deck_click(object sender, EventArgs e)
        {
            if (this.chbox_deletedeck.Checked)
            {
                
                if (MessageBox.Show("Are you sure want to delete this deck?", "Think twice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DeleteDeckEvent!=null)
                    {
                        DeleteDeckEvent(sender, e);
                    }
                }
            }
        }
        
        private void btn_newdeck_Click(object sender, EventArgs e)
        {
            if (CreateNewDeckEvent!=null)
            {
                CreateNewDeckEvent();
            }

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (SubmitNewDeckEvent != null)
            {
                SubmitNewDeckEvent(e, new CreateDeckEventargs(this.txt_deckname.Text));
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (CancelNewDeckEvent != null)
            {
                CancelNewDeckEvent();
            }
        }

        private void btn_deckreturn_Click(object sender, EventArgs e)
        {
            if (ReturnEvent != null)
            {
                ReturnEvent();
            }
        }
        #endregion

        private List<DeckPictureBox> _pictureDecks = new List<DeckPictureBox>();
        private List<MyPictureBox> _pictureCards = new List<MyPictureBox>();
        private List<Label> _deckTexts = new List<Label>();
        private ImageList _imgList = new ImageList();
    }    
}
