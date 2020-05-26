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

namespace DeBesteTijdVoorWetenschappers
{
    public partial class Form1 : Form
    {
        private readonly Managers.Program main = new Managers.Program();
        public Form1()
        {
            InitializeComponent();
            int[] data = main.Run();
            textBox1.Text = "Year = " + data[0].ToString() + Environment.NewLine + "Count = " + data[1].ToString();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
