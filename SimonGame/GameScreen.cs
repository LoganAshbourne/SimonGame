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
using System.Threading;
using System.Media;

namespace SimonGame
{
    public partial class GameScreen : UserControl
    {
        // Global variables
        Random random = new Random();
        int buttonCounter = 0;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //Color shapes
            //Green button transformation
            GraphicsPath greenButtonPath = new GraphicsPath();
            greenButtonPath.AddEllipse(0, 0, 400, 400);
            greenButtonPath.AddEllipse(150, 150, 100, 100);
            Region greenButtonRegion = new Region(greenButtonPath);
            greenButton.Region = greenButtonRegion;

            //Red button transformation
            GraphicsPath redButtonPath = new GraphicsPath();
            redButtonPath.AddEllipse(-200, 0, 400, 400);
            redButtonPath.AddEllipse(-50, 150, 100, 100);
            Region redButtonRegion = new Region(redButtonPath);
            redButton.Region = redButtonRegion;

            //Blue button transformation
            GraphicsPath blueButtonPath = new GraphicsPath();
            blueButtonPath.AddEllipse(-200, -200, 400, 400);
            blueButtonPath.AddEllipse(-50, -50, 100, 100);
            Region blueButtonRegion = new Region(blueButtonPath);
            blueButton.Region = blueButtonRegion;

            //Yellow button transformation
            GraphicsPath yellowButtonPath = new GraphicsPath();
            yellowButtonPath.AddEllipse(0, -200, 400, 400);
            yellowButtonPath.AddEllipse(150, -50, 100, 100);
            Region yellowButtonRegion = new Region(yellowButtonPath);
            yellowButton.Region = yellowButtonRegion;

            //Sound array
            Form1.player[0] = new SoundPlayer(SimonGame.Properties.Resources.green);
            Form1.player[1] = new SoundPlayer(SimonGame.Properties.Resources.red);
            Form1.player[2] = new SoundPlayer(SimonGame.Properties.Resources.blue);
            Form1.player[3] = new SoundPlayer(SimonGame.Properties.Resources.yellow);
            Form1.player[4] = new SoundPlayer(SimonGame.Properties.Resources.mistake);

            //Clear pattern lists
            Form1.gamePattern.Clear();
            Form1.guessPattern.Clear();

            //Refresh screen
            Refresh();

            //Wait 1 second
            Thread.Sleep(1000);

            //
            ComputerTurn();
        }

        public void ComputerTurn()
        {
            //Get a random number between 0 and 3, then add it to game pattern
            int randomNumber = random.Next(0, 4);
            Form1.gamePattern.Add(randomNumber);

            for (int i = 0; i < Form1.gamePattern.Count(); i++)
            {
                //Check if random number was 0 for green
                if (Form1.gamePattern[i] == 0)
                {
                    //Make green button change colour
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.Lime;
                    Refresh();

                    //Play a green sound
                    Form1.player[0].Play();

                    //Make green button change back
                    Thread.Sleep(750);
                    greenButton.BackColor = Color.Green;
                    Refresh();
                }

                //Check if random number was 1 for red
                else if (Form1.gamePattern[i] == 1)
                {
                    //Make red button change brighter
                    Thread.Sleep(500);
                    redButton.BackColor = Color.Red;
                    Refresh();

                    //Play a red sound
                    Form1.player[1].Play();

                    // Make red button change back
                    Thread.Sleep(750);
                    redButton.BackColor = Color.Maroon;
                    Refresh();
                }

                //Check if random number was 2 for blue
                else if (Form1.gamePattern[i] == 2)
                {
                    //Make blue button change brighter
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.Blue;
                    Refresh();

                    //Play a blue sound
                    Form1.player[2].Play();

                    // Make blue button change back
                    Thread.Sleep(750);
                    blueButton.BackColor = Color.Navy;
                    Refresh();
                }

                //Check if random number was 3 for yellow
                else if (Form1.gamePattern[i] == 3)
                {
                    //Make yellow button change brighter
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Yellow;
                    Refresh();

                    //Play a yellow sound
                    Form1.player[3].Play();

                    //Make yellow button change back
                    Thread.Sleep(750);
                    yellowButton.BackColor = Color.Olive;
                    Refresh();
                }
            }

            //Clear guess pattern from last round
            Form1.guessPattern.Clear();
        }

        public void PlayerTurn()
        {
            // Check if guess was correct
            if (Form1.guessPattern[buttonCounter] == Form1.gamePattern[buttonCounter])
            {
                // Check if round is over, then move to next round
                if (Form1.guessPattern.Count() == Form1.gamePattern.Count())
                {                  
                    Form1.round++;
                    roundLabel.Text = "Round: " + (Form1.round + 1);
                    ComputerTurn();
                    buttonCounter = -1;
                }
            }

            // If guess was incorrect, play GameOver method
            else
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            //Play gameover sound
            Form1.player[4].Play();

            // Wait 2 seconds
            Thread.Sleep(2000);

            // Change to game over screen
            Form f = FindForm();
            f.Controls.Remove(this);
            GameOverScreen gos = new GameOverScreen();
            f.Controls.Add(gos);

        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            Form1.player[0].Play();
            Form1.guessPattern.Add(0);

            PlayerTurn();
            buttonCounter++;                  
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            Form1.player[1].Play();
            Form1.guessPattern.Add(1);

            PlayerTurn();
            buttonCounter++;         
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            Form1.player[2].Play();
            Form1.guessPattern.Add(2);

            PlayerTurn();
            buttonCounter++;
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            Form1.player[3].Play();
            Form1.guessPattern.Add(3);

            PlayerTurn();
            buttonCounter++;
        }
    }
}
