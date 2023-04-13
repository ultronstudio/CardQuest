using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardQuest.Helpers
{
    public class Alert
    {
        public static DialogResult ShowInformation(string message, MessageBoxButtons buttons)
        {
            SystemSounds.Hand.Play();
            return MessageBox.Show(message, "Informace", buttons, MessageBoxIcon.Information);
        }
    }
}
