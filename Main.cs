using CardQuest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardQuest
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.Image = Resources.play_hover;
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Image = Resources.play_normal;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Image = Resources.play_click;
            SoundPlayer player = new SoundPlayer(Resources.mouse_click);
            player.Play();
            Game gameWindow = new Game();
            gameWindow.ShowDialog();
        }
    }
}
