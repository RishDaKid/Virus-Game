using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VirusOpdracht
{
    class Computer : AI
    {
        public Brush SpelerKleur { get; set; } //get SpelerKleur

        public Computer()
        {
            SpelerKleur = Brushes.Blue; //Sets color of the Computer
        }

        public void MakeAMove(bool _eersteclick, bool _Playerturn, int size, int _StartWaarde)
        {
            AiTurn(_eersteclick, _Playerturn, size, _StartWaarde);	//makes AI move
        }
    }    
}
