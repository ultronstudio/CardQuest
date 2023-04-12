using CardQuest.Helpers;
using CardQuest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CardQuest
{
    public partial class Game : Form
    {
        public PictureBox[] pictureBox = new PictureBox[4];
        byte[] karty = new byte[4];

        private string cardsImagePath = @"C:\Users\pvurm\OneDriveSPS\OneDrive - SPŠ, SOŠ a SOU, Hradec Králové\Projekty\CardQuest\Resources\Cards";
        string hodnotyKaret = "A,2,3,4,5,6,7,8,9,10,J,Q,K";
        bool kartyZobrazeny = false;

        public Game()
        {
            InitializeComponent();
        }

        private void btnDisplayCards_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Resources.mouse_click);
            player.Play();

            if (kartyZobrazeny == false)
            {
                CreateCard();
                DisplayControls();
                kartyZobrazeny = true;
            }
            else
            {
                RemoveControls();
                kartyZobrazeny = false;
            }
        }

        private void CreateCard()
        {
            for (int i = 0; i < pictureBox.Length; i++)
            {
                PictureBox newPictureBox = new PictureBox();
                newPictureBox.Width = 107;
                newPictureBox.Height = 550;
                newPictureBox.BackColor = Color.Transparent;
                newPictureBox.BorderStyle = BorderStyle.None;
                pictureBox[i] = SizeImage(newPictureBox, i + 1);
            }

            Cards.ShuffleArray(pictureBox);
        }

        private PictureBox SizeImage(PictureBox pictureBox, int i)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile($"{cardsImagePath}\\tile{i}.png");
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.Image = image;

            return pictureBox;
        }

        private void DisplayControls()
        {
            for (int i = 0; i < pictureBox.Length; i++)
            {
                pictureBox[i].Left = (i * 110) + 100;
                Controls.Add(pictureBox[i]);
            }
        }

        private void RemoveControls()
        {
            for (int i = 0; i < pictureBox.Length; i++)
            {
                Controls.Remove(pictureBox[i]);
            }
        }
    }
}
