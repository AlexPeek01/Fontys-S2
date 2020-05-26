using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Managers
{
    public class ColourManager
    {
        public Color GetColourToSet(Color currentColour)
        {
            if (currentColour == Color.White)
            {
               return Color.Red;
            }
            return Color.White;
        }
    }
}
