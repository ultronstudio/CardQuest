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
        public Button[] pictureBox = new Button[4];

        private string cardsImagePath = @"C:\Users\pvurm\OneDriveSPS\OneDrive - SPŠ, SOŠ a SOU, Hradec Králové\Projekty\CardQuest\Resources\Cards";
        bool kartyZobrazeny = false;
        int maxKaret = 2;
        bool[] otoceneKarty = {false, false, false, false};

        Karta karta = new Karta();

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
                Button newPictureBox = new Button();
                newPictureBox.Width = 107;
                newPictureBox.Height = 500;
                newPictureBox.BackColor = Color.Transparent;
                pictureBox[i] = SizeImage(newPictureBox, i + 1);
            }

            Cards.ShuffleArray(pictureBox);
        }

        private Button SizeImage(Button pictureBox, int i)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile($"{cardsImagePath}\\deck-top.png");

            pictureBox.Name = $"btnCard{i}";
            pictureBox.AutoSize = true;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.FlatStyle = FlatStyle.Flat;
            pictureBox.FlatAppearance.BorderSize = 0;
            pictureBox.FlatAppearance.MouseDownBackColor = Color.Transparent;
            pictureBox.FlatAppearance.MouseOverBackColor = Color.Transparent;
            pictureBox.Image = image;
            pictureBox.Click += new EventHandler((sender, e) => btnCard_Click(sender, e, i, pictureBox));

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

        private void btnCard_Click(object sender, EventArgs e, int i, Button button)
        {
            if (otoceneKarty[i-1] == true)
            {
                MessageBox.Show("Tuto kartu jsi již otočil");
            }
            else if (maxKaret != 0)
            {
                SoundPlayer player = new SoundPlayer(Resources.mouse_click);
                player.Play();

                System.Drawing.Image image = System.Drawing.Image.FromFile($"{cardsImagePath}\\tile{i}.png");
                button.Image = image;
                otoceneKarty[i-1] = true;
                maxKaret--;
            }
            else
            {
                MessageBox.Show("Otočil jsi max karet");
            }
        }
    }
}
