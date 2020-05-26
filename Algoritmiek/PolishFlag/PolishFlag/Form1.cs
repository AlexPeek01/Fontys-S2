using Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolishFlag
{
    public partial class Form1 : Form
    {
        private readonly ColourManager colourmanager = new ColourManager();
        private readonly SorterManager sortermanager = new SorterManager();
        public Form1()
        {
            InitializeComponent();

        }
        private void Button_1_Click(object sender, EventArgs e)
        {
            Button_1.BackColor = colourmanager.GetColourToSet(Button_1.BackColor);
        }
        private void Button_2_Click(object sender, EventArgs e)
        {
            Button_2.BackColor = colourmanager.GetColourToSet(Button_2.BackColor);
        }
        private void Button_3_Click(object sender, EventArgs e)
        {
            Button_3.BackColor = colourmanager.GetColourToSet(Button_3.BackColor);
        }
        private void Button_4_Click(object sender, EventArgs e)
        {
            Button_4.BackColor = colourmanager.GetColourToSet(Button_4.BackColor);
        }
        private void Button_5_Click(object sender, EventArgs e)
        {
            Button_5.BackColor = colourmanager.GetColourToSet(Button_5.BackColor);
        }
        private void Button_6_Click(object sender, EventArgs e)
        {
            Button_6.BackColor = colourmanager.GetColourToSet(Button_6.BackColor);
        }
        private void Button_7_Click(object sender, EventArgs e)
        {
            Button_7.BackColor = colourmanager.GetColourToSet(Button_7.BackColor);
        }
        private void Button_8_Click(object sender, EventArgs e)
        {
            Button_8.BackColor = colourmanager.GetColourToSet(Button_8.BackColor);
        }
        private void Button_9_Click(object sender, EventArgs e)
        {
            Button_9.BackColor = colourmanager.GetColourToSet(Button_9.BackColor);
        }
        private void Button_10_Click(object sender, EventArgs e)
        {
            Button_10.BackColor = colourmanager.GetColourToSet(Button_10.BackColor);
        }
        private void Button_11_Click(object sender, EventArgs e)
        {
            Button_11.BackColor = colourmanager.GetColourToSet(Button_11.BackColor);
        }
        private void Order_Btn_Click(object sender, EventArgs e)
        {
            List<Color> colours = new List<Color>();
            #region Filling the list
            colours.Add(Button_1.BackColor);
            colours.Add(Button_2.BackColor);
            colours.Add(Button_3.BackColor);
            colours.Add(Button_4.BackColor);
            colours.Add(Button_5.BackColor);
            colours.Add(Button_6.BackColor);
            colours.Add(Button_7.BackColor);
            colours.Add(Button_8.BackColor);
            colours.Add(Button_9.BackColor);
            colours.Add(Button_10.BackColor);
            colours.Add(Button_11.BackColor);
            #endregion
            colours = sortermanager.SortList(colours);
            #region setButtonColours
            Button_1.BackColor = colours[0];
            Button_2.BackColor = colours[1];
            Button_3.BackColor = colours[2];
            Button_4.BackColor = colours[3];
            Button_5.BackColor = colours[4];
            Button_6.BackColor = colours[5];
            Button_7.BackColor = colours[6];
            Button_8.BackColor = colours[7];
            Button_9.BackColor = colours[8];
            Button_10.BackColor = colours[9];
            Button_11.BackColor = colours[10];
            #endregion
        }
    }
}
