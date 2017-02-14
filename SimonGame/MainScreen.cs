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

        private void newGameButton_Click(object sender, EventArgs e)
        {
            // Change to game screen
            Form f = this.FindForm();
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
            f.Controls.Remove(this);
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close game
            Application.Exit();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            // Exit button
            GraphicsPath exitButtonPath = new GraphicsPath();
            exitButtonPath.AddEllipse(-175, -75, 400, 150);
            Region exitButtonRegion = new Region(exitButtonPath);
            exitButton.Region = exitButtonRegion;

            // New game button
            GraphicsPath newGameButtonPath = new GraphicsPath();
            newGameButtonPath.AddEllipse(-175, 0, 400, 150);
            Region newGameButtonRegion = new Region(newGameButtonPath);
            newGameButton.Region = newGameButtonRegion;
        }
    }
}
