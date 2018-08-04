using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VirusOpdracht
{
	class Vakje
	{
        Mens mens = new Mens(); //associatie met mens
        Computer computer = new Computer(); //associatie met computer
		private int _x_counter; //x-as van de vakjes
		private int _y_counter; //y-as van de vakjes
        private int twaalf; //vaste waarde 12
        private int nul; //vaste waarde 0
		public int vakSize;    //size of the vakjes
		public Brush color; //kleur van de brush
		private bool _bepaal;//if bepaal is  not true then this will loop through every nabour again to see if the first clicked vakje is next to a nabour vakje from the last clicked vakje
        private bool _dubbelezet; //is een dubbelezet mogelijk
		public int[] coordinaten = new int[2];	//array for the coordinates of the vakjes

		public List<Vakje> buren = new List<Vakje>();   //new list for all the buren

        public Vakje()	//Gives all the variabels its values
		{
            _x_counter = 0;
            _y_counter = 0;
            twaalf = 12;
            nul = 0;
            vakSize = 50;
            color = Brushes.White;
            _bepaal = false;
            _dubbelezet = false;
        }
        public bool GetBepaal
        {
           get { return _bepaal; } //sets the value of GetBepaal equal to the value of bepaal
        }

        public bool GetDubbelezet
        {
            get { return _dubbelezet; } //sets the value of GetGubbelezet equal to the value of dubbelezet
        }

        public void ResetBepaal()	//changes bepaal when reset button is clicked, so it doesn't keep resetting
        {
            _bepaal = false;
        }

        public void Check(Brush kleur, Brush vakkleur, int[] cordinaten, Vakje oudvak) //checks if the set is legal
        {
            _bepaal = false;
            if (computer.SpelerKleur != vakkleur && mens.SpelerKleur != vakkleur)
            {
                
                foreach (Vakje vakje in buren) //loops through every neighbour vakje of the clicked vakje
                {

                    if (vakje.coordinaten[0] == cordinaten[0] && vakje.coordinaten[1] == cordinaten[1])   //is the first clicked vakje one of my nabour vakjes?
                    {
                        _bepaal = true; //if so then bepaal is set to true. Which means that the set is legal
                    }  
                    if (_bepaal)	//if bepaal is true, stop foreach
                    {
                        break;
                    }
                }
                if (!_bepaal) //if bepaal is still not true then this will loop through every neighbour again to see if the first clicked vakje is next to a neighbour vakje from the last clicked vakje
                {
                    foreach (Vakje vakje in buren)
                    {
                        if (vakje.coordinaten[0] - vakSize == cordinaten[0] && vakje.coordinaten[1] - vakSize == cordinaten[1])
                        {
                            _bepaal = true;
                            _dubbelezet = true;
                        }
                        else if (vakje.coordinaten[0] - vakSize == cordinaten[0] && vakje.coordinaten[1] + vakSize == cordinaten[1])
                        {
                            _bepaal = true;
                            _dubbelezet = true;
                        }
                        else if (vakje.coordinaten[0] - vakSize == cordinaten[0] && vakje.coordinaten[1] == cordinaten[1])
                        {
                            _bepaal = true;
                            _dubbelezet = true;
                        }
                        else if (vakje.coordinaten[0] == cordinaten[0] && vakje.coordinaten[1] + vakSize == cordinaten[1])
                        {
                            _bepaal = true;
                            _dubbelezet = true;
                        }
                        else if (vakje.coordinaten[0] + vakSize == cordinaten[0] && vakje.coordinaten[1] + vakSize == cordinaten[1])
                        {
                            _bepaal = true;
                            _dubbelezet = true;
                        }
                        else if (vakje.coordinaten[0] + vakSize == cordinaten[0] && vakje.coordinaten[1] == cordinaten[1])
                        {
                            _bepaal = true;
                            _dubbelezet = true;
                        }
                        else if (vakje.coordinaten[0] + vakSize == cordinaten[0] && vakje.coordinaten[1] - vakSize == cordinaten[1])
                        {
                            _bepaal = true;
                            _dubbelezet = true;
                        }
                        else if (vakje.coordinaten[0] == cordinaten[0] && vakje.coordinaten[1] - vakSize == cordinaten[1])
                        {
                            _bepaal = true;
                            _dubbelezet = true;
                        }
                        if (_bepaal)
                        {
                            break;
                        }
                    }
                }
            }
        }
        public void ResetColor(Bitmap _buffer, int[] cooridnaten, int _size, Brush kleur)
        {
            color = kleur;	//color is kleur of the current player
            using (Graphics graphics = Graphics.FromImage(_buffer)) //clicking on the bitmap with the right color
            {
                graphics.FillRectangle(color, coordinaten[0], coordinaten[1], _size, _size);
            }
        }

		public void VeranderKleur(Bitmap _buffer, int[] cooridnaten, int _size, Brush kleur)
		{
			color = kleur;	//color is kleur of the current player

			using (Graphics graphics = Graphics.FromImage(_buffer)) //het klikken op de bitmap met de juiste kleur voor de juiste speler
			{
				graphics.FillRectangle(color, coordinaten[0], coordinaten[1], _size, _size);
                
                foreach (Vakje vakjent in buren)
                {
                    if (kleur == mens.SpelerKleur && vakjent.color == Brushes.Blue)	//if kleur is playercolor, color is blue
                    {
                        graphics.FillRectangle(color, vakjent._x_counter * vakSize, vakjent._y_counter * vakSize, _size, _size);	//fills the clicked square with the right color
                        vakjent.color = kleur;	//resets the color
                    }
                    else if (kleur == Brushes.Blue && vakjent.color == mens.SpelerKleur)
                    {
                        graphics.FillRectangle(color, vakjent._x_counter * vakSize, vakjent._y_counter * vakSize, _size, _size);	//fills the clicked square with the right color
						vakjent.color = kleur;	//resets the color
                    }
                }
			}
            _bepaal = !_bepaal;	//bepaal is back to false
		}

		public void TekenSpel(Bitmap _buffer, int i, int j)	//draws the game
		{
            Bitmap _plek; //de bitmap
            _plek = _buffer;	//bitmap is now the buffer
			_x_counter = i;	//x_counter is now the same as int i
			_y_counter = j;	//y_counter is now the same as int j

			coordinaten[0] = _x_counter * vakSize;   //x-place of the vakje
			coordinaten[1] = _y_counter * vakSize;   //y-place of the vakje
			Kleur(_plek, _x_counter, _y_counter);	//activate method Kleur
			StartPunt(_plek, _x_counter, _y_counter);	//activate method StartPunt
		}

		public void Kleur(Bitmap _buffer, int x, int y)	//determines the color of the squares
		{
			using (Graphics graphics = Graphics.FromImage(_buffer))	//using bitmap buffer
			{
				if ((x + y) % 2 == nul)
				{
                    color = Brushes.White;	
					graphics.FillRectangle(Brushes.White, coordinaten[0], coordinaten[1], vakSize, vakSize);    //half of the vakjes are white
				}
				else
				{
                    color = Brushes.Black;
                    graphics.FillRectangle(Brushes.Black, coordinaten[1], coordinaten[0], vakSize, vakSize);    //half of the vakjes are black
				}
			}
		}

		public void StartPunt(Bitmap _buffer, int x, int y)	//makes the beginpoint of the players
		{
			using (Graphics graphics = Graphics.FromImage(_buffer))	//using bitmap buffer
			{
				if ((x + y) == nul)
				{
					color = mens.SpelerKleur;
					graphics.FillRectangle(color, coordinaten[0], coordinaten[1], vakSize, vakSize);    //sets the starting point of the human
				}
				else if ((x + y) == twaalf)
				{
					color = Brushes.Blue;
					graphics.FillRectangle(color, coordinaten[0], coordinaten[1], vakSize, vakSize);    //sets the starting point of the ai
				}
			}
		}

		public void ZetBuur(Vakje vakje) //add the buur to the list
		{
			buren.Add(vakje); 
		}
	}
}
