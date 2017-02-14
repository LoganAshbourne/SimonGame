using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonGame
{
    public partial class Form1 : Form
    {
        // Global lists
        public static List<int> gamePattern = new List<int>();
        public static List<int> guessPattern = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start main screen
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);
        }
    }
}
