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
        int buttonCounter;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            // Color shapes
                // Green button transformation
                GraphicsPath greenButtonPath = new GraphicsPath();
                greenButtonPath.AddEllipse(0, 0, 400, 400);
                greenButtonPath.AddEllipse(150, 150, 100, 100);
                Region greenButtonRegion = new Region(greenButtonPath);
                greenButton.Region = greenButtonRegion;

                // Red button transformation
                GraphicsPath redButtonPath = new GraphicsPath();
                redButtonPath.AddEllipse(-200, 0, 400, 400);
                redButtonPath.AddEllipse(-50, 150, 100, 100);
                Region redButtonRegion = new Region(redButtonPath);
                redButton.Region = redButtonRegion;

                // Blue button transformation
                GraphicsPath blueButtonPath = new GraphicsPath();
                blueButtonPath.AddEllipse(-200, -200, 400, 400);
                blueButtonPath.AddEllipse(-50, -50, 100, 100);
                Region blueButtonRegion = new Region(blueButtonPath);
                blueButton.Region = blueButtonRegion;

                // Yellow button transformation
                GraphicsPath yellowButtonPath = new GraphicsPath();
                yellowButtonPath.AddEllipse(0, -200, 400, 400);
                yellowButtonPath.AddEllipse(150, -50, 100, 100);
                Region yellowButtonRegion = new Region(yellowButtonPath);
                yellowButton.Region = yellowButtonRegion;               

            // Sound array
            Form1.player[0] = new SoundPlayer(SimonGame.Properties.Resources.green);
            Form1.player[1] = new SoundPlayer(SimonGame.Properties.Resources.red);
            Form1.player[2] = new SoundPlayer(SimonGame.Properties.Resources.blue);
            Form1.player[3] = new SoundPlayer(SimonGame.Properties.Resources.yellow);
            Form1.player[4] = new SoundPlayer(SimonGame.Properties.Resources.mistake);

            // Clear pattern list
            Form1.gamePattern.Clear();
            Form1.guessPattern.Clear();

            Thread.Sleep(1000);

            // Refresh screen
            Refresh();
        }

        public void ComputerTurn()
        {
            int randomNumber = random.Next(0, 1);
            Form1.gamePattern.Add(randomNumber);

            for (int i = 0; i < Form1.gamePattern.Count(); i++)
            {
                if (Form1.gamePattern[i] == 0)
                {
                    //Play a green sound
                    Form1.player[0].Play();

                    //TODO Make green button change colour
                    Thread.Sleep(1000);
                    greenButton.BackColor = Color.Lime;
                    Thread.Sleep(1000);
                    greenButton.BackColor = Color.Green;
                }

                else if (Form1.gamePattern[i] == 1)
                {
                    //Play a red sound
                    Form1.player[1].Play();

                    //TODO Make red button change colour
                    redButton.BackColor = Color.Red;
                }

                else if (Form1.gamePattern[i] == 2)
                {
                    //Play a blue sound
                    Form1.player[2].Play();

                    //TODO Make blue button change colour
                    blueButton.BackColor = Color.Blue;
                }

                else if (Form1.gamePattern[i] == 3)
                {
                    //Play a yellow sound
                    Form1.player[3].Play();

                    //TODO Make yellow button change colour
                    yellowButton.BackColor = Color.Yellow;
                }

                Thread.Sleep(2000);
            }

            Form1.guessPattern.Clear(); 
        }

        public void PlayerTurn()
        {
            for (int i = 0; i < Form1.guessPattern.Count(); i++)
            {
                if (Form1.guessPattern[i] == Form1.gamePattern[i])
                {
                    ComputerTurn();
                }

                else
                {
                    GameOver();
                }
            }

            Form1.round++;
            roundLabel.Text = "Round: " + Form1.round;
        }

        public void GameOver()
        {
            //Play gameover sound
            Form1.player[4].Play();

            // Wait 2 seconds
            Thread.Sleep(2000);

            // Change to game over screen
            Form f = this.FindForm();
            GameOverScreen gos = new GameOverScreen();
            f.Controls.Add(gos);
            f.Controls.Remove(this);
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            Form1.player[0].Play();
            Form1.guessPattern.Add(0);

            buttonCounter++;

            if (Form1.gamePattern.Count() < buttonCounter)
            {
              PlayerTurn();

              buttonCounter = 0;
            }
            
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            Form1.player[1].Play();
            Form1.guessPattern.Add(1);

            buttonCounter++;

            if (Form1.gamePattern.Count() < buttonCounter)
            {
                PlayerTurn();

                buttonCounter = 0;
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            Form1.player[2].Play();
            Form1.guessPattern.Add(2);

            buttonCounter++;

            if (Form1.gamePattern.Count() < buttonCounter)
            {
                PlayerTurn();

                buttonCounter = 0;
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            Form1.player[3].Play();
            Form1.guessPattern.Add(3);

            buttonCounter++;

            if (Form1.gamePattern.Count() < buttonCounter)
            {
                PlayerTurn();

                buttonCounter = 0;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Run computer turn custom method
            ComputerTurn();
        }
    }
}
