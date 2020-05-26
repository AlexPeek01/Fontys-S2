using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Scientist
    {
        public string name { get; set; }
        public int birth { get; set; }
        public int death { get; set; }
        public Scientist(string name, int birth, int death)
        {
            this.name = name;
            this.birth = birth;
            this.death = death;
        }
    }
}
