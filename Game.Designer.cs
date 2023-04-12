namespace CardQuest
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.pboxCards = new System.Windows.Forms.PictureBox();
            this.btnDisplayCards = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCards)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxCards
            // 
            this.pboxCards.BackColor = System.Drawing.Color.Transparent;
            this.pboxCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pboxCards.Location = new System.Drawing.Point(0, 0);
            this.pboxCards.Name = "pboxCards";
            this.pboxCards.Size = new System.Drawing.Size(800, 92);
            this.pboxCards.TabIndex = 0;
            this.pboxCards.TabStop = false;
            // 
            // btnDisplayCards
            // 
            this.btnDisplayCards.Location = new System.Drawing.Point(12, 415);
            this.btnDisplayCards.Name = "btnDisplayCards";
            this.btnDisplayCards.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayCards.TabIndex = 1;
            this.btnDisplayCards.Text = "Ukaž karty";
            this.btnDisplayCards.UseVisualStyleBackColor = true;
            this.btnDisplayCards.Click += new System.EventHandler(this.btnDisplayCards_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CardQuest.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDisplayCards);
            this.Controls.Add(this.pboxCards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.pboxCards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxCards;
        private System.Windows.Forms.Button btnDisplayCards;
    }
}