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

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //TODO Show pattern length player reached

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Change to main screen
            Form f = this.FindForm();
            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);
            f.Controls.Remove(this);
        }
    }
}
