using Managers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    public partial class Form1 : Form
    {
        private readonly Guesses guesses = new Guesses();
        private List<string> guess;
        private int correctPositions;

        public Form1()
        {
            InitializeComponent();
            correctPositions = 0;
        }

        private void InputField_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !("\b01".Contains(e.KeyChar));
            textBox1.Text = "";
        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guess_Btn_Click(object sender, EventArgs e)
        {
            // Turn textbox input into List
            List<Position> tokens = new List<Position>();
            for (int i = 0; i < InputField.Text.Length; i++)
            {
                tokens.Add(new Position(InputField.Text.Substring(i, 1), false));
            }

            // Make initial guess
            if (guess == null)
                guess = guesses.InitialGuess(tokens.Count);

            // Make guess
            if (guess != null && tokens.Count == guess.Count)
            guess = guesses.MakeGuess(guess, tokens, correctPositions);
            correctPositions = guesses.GetCorrectPositionCount(tokens, guess);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
