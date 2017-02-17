/* Program: Simon Game
 * Created by: Logan Ashbourne
 * Date: 2017-02-21
 * Desc: A pattern color game that tests your memorization skills
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SimonGame
{
    public partial class Form1 : Form
    {
        //Public global lists
        public static List<int> gamePattern = new List<int>();
        public static List<int> guessPattern = new List<int>();
        public static List<Button> buttonList = new List<Button>();
        public static SoundPlayer[] player = new SoundPlayer[5];
        public static int round = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //Start main screen
        private void Form1_Load(object sender, EventArgs e)
        {
            //Start main screen
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);
        }
    }
}
