namespace UserInterface
{
    partial class ShopInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopInterface));
            this.btn_return = new System.Windows.Forms.Button();
            this.lbl_playerName = new System.Windows.Forms.Label();
            this.lbl_playerPoints = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_return
            // 
            this.btn_return.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_return.BackColor = System.Drawing.Color.White;
            this.btn_return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_return.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_return.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_return.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_return.Font = new System.Drawing.Font("Stencil", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_return.Location = new System.Drawing.Point(570, 567);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(100, 50);
            this.btn_return.TabIndex = 28;
            this.btn_return.Text = "Return";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // lbl_playerName
            // 
            this.lbl_playerName.AutoSize = true;
            this.lbl_playerName.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerName.Location = new System.Drawing.Point(1131, 9);
            this.lbl_playerName.Name = "lbl_playerName";
            this.lbl_playerName.Size = new System.Drawing.Size(79, 22);
            this.lbl_playerName.TabIndex = 29;
            this.lbl_playerName.Text = "Player";
            // 
            // lbl_playerPoints
            // 
            this.lbl_playerPoints.AutoSize = true;
            this.lbl_playerPoints.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerPoints.Location = new System.Drawing.Point(1131, 40);
            this.lbl_playerPoints.Name = "lbl_playerPoints";
            this.lbl_playerPoints.Size = new System.Drawing.Size(77, 22);
            this.lbl_playerPoints.TabIndex = 30;
            this.lbl_playerPoints.Text = "Points";
            // 
            // ShopInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.lbl_playerPoints);
            this.Controls.Add(this.lbl_playerName);
            this.Controls.Add(this.btn_return);
            this.DoubleBuffered = true;
            this.Name = "ShopInterface";
            this.Text = "ShopInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Label lbl_playerName;
        private System.Windows.Forms.Label lbl_playerPoints;
    }
}