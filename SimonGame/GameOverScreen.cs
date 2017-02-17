using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonGame
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        //Calculate pattern length, and show
        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //Calculate pattern length, and show
            patternLengthLabel.Text += Form1.round;
        }

        //Change to main screen
        private void closeButton_Click(object sender, EventArgs e)
        {
            //Change to main screen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);
            
        }
    }
}
