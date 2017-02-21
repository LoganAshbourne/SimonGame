using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SimonGame
{
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        //Change to game screen
        private void newGameButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);       
        }

        //Close game
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Button shape changes
        private void MainScreen_Load(object sender, EventArgs e)
        {
            //Exit button
            GraphicsPath exitButtonPath = new GraphicsPath();
            exitButtonPath.AddEllipse(-175, -75, 400, 150);
            exitButton.Region = new Region(exitButtonPath);

            //New game button
            GraphicsPath newGameButtonPath = new GraphicsPath();
            newGameButtonPath.AddEllipse(-175, 0, 400, 150);
            newGameButton.Region = new Region(newGameButtonPath);
        }
    }
}
