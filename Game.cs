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
        Button[] pictureBox = new Button[16];
        private static string cardsImagePath = @"C:\Users\pvurm\OneDriveSPS\OneDrive - SPŠ, SOŠ a SOU, Hradec Králové\Projekty\CardQuest\Resources\Cards";
        public static int pocetKaret = 4;

        public static bool kartyZobrazeny = false;
        public static int maxKaret = 2;
        public static bool[] otoceneKarty = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, };

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
                DisplayControls(pictureBox, pocetKaret);
                kartyZobrazeny = true;
            }
            else
            {
                /*
                 * RemoveControls(pictureBox, pocetKaret);
                 * kartyZobrazeny = false;
                */
                Alert.ShowInformation("Karty již byly rozdány. Musíš hrát s tím, co máš", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Vytvoří jednotlivé karty, které se pak náhodně "zamýchají"
        /// </summary>
        private void CreateCard()
        {
            for (int i = 0; i < pictureBox.Length; i++)
            {
                Button newPictureBox = new Button();
                newPictureBox.Width = 110;
                newPictureBox.Height = 500;
                newPictureBox.BackColor = Color.Transparent;
                pictureBox[i] = SizeImage(newPictureBox, i + 1);
            }

            Cards.ShuffleArray(pictureBox);
        }

        /// <summary>
        /// Vytvoří se jednotlivé tlačítko
        /// </summary>
        /// <param name="pictureBox">Pole tlačítek, do kterého se má vytvořené tlačítko vložit</param>
        /// <param name="i">Index vytvářeného tlačítka</param>
        /// <returns>Vytvořené tlačítko</returns>
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

        /// <summary>
        /// Zobrazí vytvořené karty
        /// </summary>
        /// <param name="buttons">Pole tlačítek, ze kterého mají být karty vybírány</param>
        /// <param name="limit">Limit karet, které se mohou zobrazit</param>
        private void DisplayControls(Button[] buttons, int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                buttons[i].Left = (i * 150) + 100;
                Controls.Add(buttons[i]);
            }
        }

        /// <summary>
        /// Odstraní vytvořené karty
        /// </summary>
        /// <param name="buttons">Pole tlačítek, ze kterého mají být karty "odstraněny"</param>
        /// <param name="limit">Počet karet, které se mají odstranit
        private void RemoveControls(Button[] buttons, int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                Controls.Remove(buttons[i]);
            }
        }

        /// <summary>
        /// Event kliknutí na tlačítko jednotlivých karet
        /// </summary>
        /// <param name="i">Index karty</param>
        /// <param name="button">Tlačítko karty</param>
        private void btnCard_Click(object sender, EventArgs e, int i, Button button)
        {
            // pokud byla již daná karta otočena
            if (otoceneKarty[i-1] == true)
            {
                Alert.ShowInformation("Tuto kartu jsi již otočil", MessageBoxButtons.OK);
            }
            // pokud ještě nebyl překročen limit maximálního počtu otočených karet
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
                Alert.ShowInformation("Otočil jsi maximální počet karet", MessageBoxButtons.OK);
            }
        }
    }
}
