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

namespace SimonGame
{
    public partial class GameScreen : UserControl
    {
        // Global variables
        Random random = new Random();
        int round = 1;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            // Color shapes
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

                // Green button transformation
                GraphicsPath greenButtonPath = new GraphicsPath();
                greenButtonPath.AddEllipse(0, 0, 400, 400);
                greenButtonPath.AddEllipse(150, 150, 100, 100);
                Region greenButtonRegion = new Region(greenButtonPath);
                greenButton.Region = greenButtonRegion;

            // Refresh screen
            Refresh();

            // Clear pattern list
            Form1.gamePattern.Clear();

            // Wait 2 seconds
            Thread.Sleep(2000);

            // Run computer turn custom method
            ComputerTurn();
        }

        public void ComputerTurn()
        {
            int randomNumber = random.Next(1, 2);
            Form1.gamePattern.Add(randomNumber);

            for (int i = 0; i < Form1.gamePattern.Count(); i++)
            {
                if (Form1.gamePattern[i] == 1)
                {
                    //TODO Play a sound

                    greenButton.BackColor = Color.Green;
                    Refresh();
                    Thread.Sleep(1000);
                    greenButton.BackColor = Color.Lime;
                    Refresh();
                    Thread.Sleep(1000);
                    greenButton.BackColor = Color.Green;
                    Refresh();
                }

                else if (Form1.gamePattern[i] == 2)
                {
                    //TODO Play a sound

                    redButton.BackColor = Color.Maroon;
                    Thread.Sleep(1000);
                    redButton.BackColor = Color.Red;
                    Thread.Sleep(1000);
                    redButton.BackColor = Color.Maroon;
                }

                else if (Form1.gamePattern[i] == 3)
                {
                    //TODO Play a sound

                    blueButton.BackColor = Color.Navy;
                    Thread.Sleep(1000);
                    blueButton.BackColor = Color.Blue;
                    Thread.Sleep(1000);
                    blueButton.BackColor = Color.Navy;
                }

                else if (Form1.gamePattern[i] == 4)
                {
                    //TODO Play a sound

                    yellowButton.BackColor = Color.Olive;
                    Thread.Sleep(1000);
                    yellowButton.BackColor = Color.Yellow;
                    Thread.Sleep(1000);
                    yellowButton.BackColor = Color.Olive;
                }

                Thread.Sleep(2000);
            }

            Form1.guessPattern.Clear(); 
        }

        public void PlayerTurn()
        {
            for (int i = 0; i < Form1.gamePattern.Count(); i++)
            {
                if (Form1.guessPattern[i] != Form1.gamePattern[i])
                {
                    GameOver();
                }

                else
                {
                    ComputerTurn();
                }
            }

            round++;
            roundLabel.Text = "Round: " + round;
        }

        public void GameOver()
        {
            //TODO Play gameover sound


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
            Form1.guessPattern.Add(1);

            PlayerTurn();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            Form1.guessPattern.Add(2);

            PlayerTurn();
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            Form1.guessPattern.Add(3);

            PlayerTurn();
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            Form1.guessPattern.Add(4);

            PlayerTurn();
        }
    }
}
