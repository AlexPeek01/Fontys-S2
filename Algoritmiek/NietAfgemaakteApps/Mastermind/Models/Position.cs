using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Position
    {
        public string character { get; set; }
        public bool lockedIn { get; set; }
        public Position(string character, bool lockedIn)
        {
            this.character = character;
            this.lockedIn = lockedIn;
        }
    }
}
