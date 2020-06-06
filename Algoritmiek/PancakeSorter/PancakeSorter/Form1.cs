using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PancakeSorter
{
    public partial class Form1 : Form
    {
        private readonly Algorithm run = new Algorithm();
        public Form1()
        {
            InitializeComponent();
        }

        private void FlipBtn_Click(object sender, EventArgs e)
        {
            Pancake[] stack = run.CreateStack().ToArray();
            foreach(Pancake c in stack)
            {
                OrigTextBox.Text += c.Size.ToString() + '\n';
            }
            run.RunAlgorithm(stack);
            foreach (Pancake c in stack)
            {
                DisplayTextBox.Text += c.Size.ToString() + '\n';
            }
        }
    }
}
