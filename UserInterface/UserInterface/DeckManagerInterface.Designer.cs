namespace UserInterface
{
    partial class DeckManagerInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckManagerInterface));
            this.btn_deckreturn = new System.Windows.Forms.Button();
            this.btn_newdeck = new System.Windows.Forms.Button();
            this.lstview_pickedCards = new System.Windows.Forms.ListView();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_deckname = new System.Windows.Forms.TextBox();
            this.lbl_deckname = new System.Windows.Forms.Label();
            this.chbox_deletedeck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_deckreturn
            // 
            this.btn_deckreturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deckreturn.BackColor = System.Drawing.Color.White;
            this.btn_deckreturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_deckreturn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_deckreturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_deckreturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_deckreturn.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deckreturn.Location = new System.Drawing.Point(12, 124);
            this.btn_deckreturn.Name = "btn_deckreturn";
            this.btn_deckreturn.Size = new System.Drawing.Size(100, 50);
            this.btn_deckreturn.TabIndex = 18;
            this.btn_deckreturn.Text = "Return";
            this.btn_deckreturn.UseVisualStyleBackColor = false;
            this.btn_deckreturn.Click += new System.EventHandler(this.btn_deckreturn_Click);
            // 
            // btn_newdeck
            // 
            this.btn_newdeck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_newdeck.BackColor = System.Drawing.Color.White;
            this.btn_newdeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_newdeck.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_newdeck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_newdeck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_newdeck.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newdeck.Location = new System.Drawing.Point(12, 12);
            this.btn_newdeck.Name = "btn_newdeck";
            this.btn_newdeck.Size = new System.Drawing.Size(100, 50);
            this.btn_newdeck.TabIndex = 15;
            this.btn_newdeck.Text = "Create new deck";
            this.btn_newdeck.UseVisualStyleBackColor = false;
            this.btn_newdeck.Click += new System.EventHandler(this.btn_newdeck_Click);
            // 
            // lstview_pickedCards
            // 
            this.lstview_pickedCards.Enabled = false;
            this.lstview_pickedCards.Font = new System.Drawing.Font("Stencil", 10F);
            this.lstview_pickedCards.FullRowSelect = true;
            this.lstview_pickedCards.Location = new System.Drawing.Point(1102, 12);
            this.lstview_pickedCards.MultiSelect = false;
            this.lstview_pickedCards.Name = "lstview_pickedCards";
            this.lstview_pickedCards.Size = new System.Drawing.Size(150, 502);
            this.lstview_pickedCards.TabIndex = 19;
            this.lstview_pickedCards.UseCompatibleStateImageBehavior = false;
            this.lstview_pickedCards.View = System.Windows.Forms.View.SmallIcon;
            this.lstview_pickedCards.Visible = false;
            // 
            // btn_submit
            // 
            this.btn_submit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_submit.BackColor = System.Drawing.Color.White;
            this.btn_submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_submit.Enabled = false;
            this.btn_submit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_submit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_submit.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(1124, 566);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(100, 50);
            this.btn_submit.TabIndex = 20;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Visible = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.BackColor = System.Drawing.Color.White;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_cancel.Enabled = false;
            this.btn_cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_cancel.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(1124, 622);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 50);
            this.btn_cancel.TabIndex = 21;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Visible = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_deckname
            // 
            this.txt_deckname.Enabled = false;
            this.txt_deckname.Location = new System.Drawing.Point(1102, 540);
            this.txt_deckname.Name = "txt_deckname";
            this.txt_deckname.Size = new System.Drawing.Size(150, 20);
            this.txt_deckname.TabIndex = 22;
            this.txt_deckname.Visible = false;
            // 
            // lbl_deckname
            // 
            this.lbl_deckname.AutoSize = true;
            this.lbl_deckname.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_deckname.Location = new System.Drawing.Point(1121, 524);
            this.lbl_deckname.Name = "lbl_deckname";
            this.lbl_deckname.Size = new System.Drawing.Size(103, 13);
            this.lbl_deckname.TabIndex = 23;
            this.lbl_deckname.Text = "Enter deck name";
            this.lbl_deckname.Visible = false;
            // 
            // chbox_deletedeck
            // 
            this.chbox_deletedeck.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbox_deletedeck.BackColor = System.Drawing.Color.White;
            this.chbox_deletedeck.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.chbox_deletedeck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbox_deletedeck.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbox_deletedeck.Location = new System.Drawing.Point(12, 68);
            this.chbox_deletedeck.Name = "chbox_deletedeck";
            this.chbox_deletedeck.Size = new System.Drawing.Size(100, 50);
            this.chbox_deletedeck.TabIndex = 24;
            this.chbox_deletedeck.Text = "Delete Deck";
            this.chbox_deletedeck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbox_deletedeck.UseVisualStyleBackColor = false;
            // 
            // DeckManagerInterface
            // 
            this.DoubleBuffered = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.chbox_deletedeck);
            this.Controls.Add(this.lbl_deckname);
            this.Controls.Add(this.txt_deckname);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.lstview_pickedCards);
            this.Controls.Add(this.btn_deckreturn);
            this.Controls.Add(this.btn_newdeck);
            this.Name = "DeckManagerInterface";
            this.Text = "DeckManagerInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_deckreturn;
        private System.Windows.Forms.Button btn_newdeck;
        private System.Windows.Forms.ListView lstview_pickedCards;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txt_deckname;
        private System.Windows.Forms.Label lbl_deckname;
        private System.Windows.Forms.CheckBox chbox_deletedeck;
    }
}