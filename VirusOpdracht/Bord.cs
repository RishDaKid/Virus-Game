using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VirusOpdracht
{
	class Bord
	{
		public Bitmap _buffer = new Bitmap(350, 350);	//create new bitmap
		public Vakje[,] vak = new Vakje[7, 7];	//associatie met vakje in 2D array
		private int size;	//const value of 7
        private int een;	//const value of 1
        private int nul;	//const value of 0

        public Bord()	//Gives all the variabels its values
		{
            size = 7;
            een = 1;
            nul = 0;
        }
        public void Maak(PictureBox pbMain)  //bitmap is given to a vakje, vakje desides its own place an size and draws itself. After that he will return the bitmap
		{
            Vakje _vakje;	//all the attributes from Vakje
            pbMain.Height = _buffer.Height;	//pbmain height is the same as buffer height
			pbMain.Width = _buffer.Width;	//pbmain width is the same as buffer width

			for (int x = nul; x < size; x++) //makes the field
			{
				for (int y = nul; y < size; y++) 
				{
					_vakje = new Vakje();	//association with vakje
					_vakje.TekenSpel(_buffer, x, y);	//activates method Tekenspel 
					vak[x, y] = _vakje;
				}
			}
			pbMain.Image = _buffer;	//pbmain image is the buffer again
			BuurCheck(vak);	//activate BuurCheck method
		}

		private void BuurCheck(Vakje[,] _vak) //checks around every vakje if it has nabour vakjes
		{
			for (int x = nul; x < size; x++) //loops with the size of the field
			{
				for (int y = nul; y < size; y++) //loops with the size of the field
				{
					if (x != nul)
					{
						_vak[x, y].ZetBuur(_vak[x - een, y]);
					}
					if (x < size - een)
					{
						_vak[x, y].ZetBuur(_vak[x + een, y]);
					}
					if (x != nul && y < size - een)
					{
						_vak[x, y].ZetBuur(_vak[x - een, y + een]);
					}
					if (x != nul && y != nul)
					{
						_vak[x, y].ZetBuur(_vak[x - een, y - een]);
					}
					if (y != nul)
					{
						_vak[x, y].ZetBuur(_vak[x, y - een]);
					}
					if (y < size - een)
					{
						_vak[x, y].ZetBuur(_vak[x, y + een]);
					}
					if (x < size - een && y < size - een)
					{
						_vak[x, y].ZetBuur(_vak[x + een, y + een]);
					}
					if (x < size - een && y != nul)
					{
						_vak[x, y].ZetBuur(_vak[x + een, y - een]);
					}
				}
			}
		}
	}
}
