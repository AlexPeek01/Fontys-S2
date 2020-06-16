using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace ContainerShip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int shipLength = Convert.ToInt32(ShipLengthNumeric.Value);
            int shipWidth = Convert.ToInt32(ShipWidthNumeric.Value);
            int shipHeight = Convert.ToInt32(ShipHeightNumeric.Value);
            Ship ship = new Ship(shipLength, shipWidth, shipHeight);
            for (int i = 0; i < CC_Box.Value; i++)
            {
                Logic.Container c1 = new Logic.Container(10000 + i, true, false, false, false);
                ship.ContainerList.Add(c1);
            }
            for (int i = 0; i <= VCC_Box.Value; i++)
            {
                Logic.Container c2 = new Logic.Container(10010 + i, true, true, false, false);
                ship.ContainerList.Add(c2);
            }
            for (int i = 0; i < NC_Box.Value; i++)
            {
                Logic.Container c3 = new Logic.Container(10000 + i, false, false, false, false);
                ship.ContainerList.Add(c3);
            }
            
            for (int i = 0; i < VC_Box.Value; i++)
            {
                Logic.Container c = new Logic.Container(10000 + i, false, true, false, false);
                ship.ContainerList.Add(c);
            }
            //Logic.Container[,,] containerArray = Algorithm.placeContainerArray(ship);
            Logic.Container[,,] containerArray = Algorithm.placeContainerArray(ship);
            int j = 0;
            foreach (Logic.Container c in containerArray)
            {
                if (c != null)
                {
                    j++;
                }
            }
            placedLabel.Text = j.ToString();
        }
    }
}

