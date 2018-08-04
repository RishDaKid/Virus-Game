using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VirusOpdracht
{
    class Mens
    {
        public Brush SpelerKleur { get; set; } //get SpelerKleur

        public Mens()
        {
            SpelerKleur = Brushes.Red; //Sets color of the human
        }
    }
}
