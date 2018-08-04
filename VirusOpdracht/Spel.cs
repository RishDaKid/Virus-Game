using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VirusOpdracht
{
    class Spel
    {
		Bord _bord = new Bord(); //associatie met Bord
        Mens _mens = new Mens(); //associatie met Mens
        Computer _computer = new Computer(); //associatie met Computer
        private int[] _tweedeclickcords;  //coordinaten van het vakje
        private int _eersteclickX; //vak op x-as van de eerst geselecteerde click
        private int _eersteclickY; // vak op y-as van de eerst geselecteerde click
        private const int _StartWaarde = 0; //vaste waarde 0
        private bool _eersteclick;//checks if zet is 0, if zet is 1 it will call Check method in class Vakje
        private const int CalculatedInt = 2; // vaste waarde
        private const int size = 7; // vaste waarde
        private int _playerscore; //playerscore standaard op 0 bij start
        private int _aiscore; //AI score standaard op 0 bij start
        private int _vakjesover; //Alle vakjes op het bord
		private Brush _kleur; //kleur van de brush
		private bool _Playerturn; //bepaal wie wanneer een zet mag doen

        public Spel()	//Gives all the variabels its values
        {		
            _eersteclickX = 0;
            _eersteclickY = 0;
            _eersteclick = true;
            _playerscore = 0;
            _aiscore = 0;
            _vakjesover = 49;
            _Playerturn = true;
        }

        public bool GetPlayerturn //returns the current value of Playerturn to the bool GetPlayerturn
        {
            get { return _Playerturn; }
        }

        public bool GetZet //returns the current value of zet to the int GetZet
        {
            get { return _eersteclick; }
        }

        public int GetScorePlayer
        {
            get { return _playerscore; } //returns the current playerscore to the int GetScorePlayer
        }

        public int GetScoreAI	//returns the current aiscore to the int GetScoreAI
		{
            get { return _aiscore; }
        }

        public void Score()
        {
            _playerscore = _StartWaarde; //set value of playerscore, aiscore and vakjesover back to 0 to recount. Otherwise points would keep counting up and they will become different to the actual number of vakjes obtained by the player or ai
            _aiscore = _StartWaarde;	
            _vakjesover = _StartWaarde;
            for (int x = _StartWaarde; x < size; x++) //loops through all vakjes
            {
                for (int y = _StartWaarde; y < size; y++)
                {
                    if (_bord.vak[x, y].color == _mens.SpelerKleur) //if the vakje is red then it will add 1 point to the playerscore
                    {
                        _playerscore++;
                    }
                    else if (_bord.vak[x, y].color == _computer.SpelerKleur) //if the vakje is Blue then it will add 1 point to the aiscore
                    {
                        _aiscore++;
                    }
                    else if (_bord.vak[x, y].color == Brushes.Black || _bord.vak[x, y].color == Brushes.White) //if the vakje is black or white then it will add 1 point to vakjesover
                    {
                        _vakjesover++;
                    }
                }
            }
		}

        public void CheckIfGameover()
        {
            if (_vakjesover == _StartWaarde || _playerscore == _StartWaarde || _aiscore == _StartWaarde) //if there are no vakjes left to click on this will call the method Spelover
            {
                _Spelover();	
            }
        }

        private void _Spelover() //checks who won
		{
            if (_playerscore - _aiscore < _StartWaarde) //if  ai won it will open a messagebox
            {
                _Playerturn = true;
                DialogResult dialog = MessageBox.Show("U bent verslagen door de AI" + "\n" + "Uw score: " + GetScorePlayer + "\n" + "AI Score: " + GetScoreAI,  //message that is displayed in the messagebox
                "Game Over", MessageBoxButtons.OK);
                if (dialog == DialogResult.OK)
                {
                    Application.Exit(); // applicatie sluit af
                }
            }

            else if (_playerscore - _aiscore > _StartWaarde)  //if  player won it will open a messagebox
            {
                _Playerturn = true;
                DialogResult dialog = MessageBox.Show("U heb gewonnen" + "\n" + "Uw score: " + GetScorePlayer + "\n" + "AI Score: " + GetScoreAI, //message that is displayed in the messagebox
                "Game Over", MessageBoxButtons.OK);

                if (dialog == DialogResult.OK)
                {
                    Application.Exit();// applicatie sluit af
                }
            }
           
        }

        public void Clicker(int x, int y) //desides what will happen when there occurs a click
		{
			Bepaal(x, y);
		}

		private void Bepaal(int x, int y) //decides how moves will be made
		{
			Vakje vank = _bord.vak[x, y]; //saves the vakje from the current click
			Vakje oudvakje = _bord.vak[_eersteclickX, _eersteclickY]; //saves the vakje from the first click
            if (_Playerturn) //if it is the playerturn then de color that is used will be red
			{
				_kleur = _mens.SpelerKleur;
			}
			else //otherwise the color will be blue
			{
				_kleur = _computer.SpelerKleur;
			}

            if (!_eersteclick) //checks if zet is 1, if so it will call Check method in class Vakje
            {
                    vank.Check(_kleur, _bord.vak[x, y].color, _tweedeclickcords, oudvakje);  
            }

             if (vank.GetBepaal == false && _eersteclick) //this will save the cordinates of the clicked vakje. This is used to see what the first clicked vakje was
            {
                _eersteclickX = x;
                _eersteclickY = y;
            }

            if (_kleur == _bord.vak[x, y].color && _eersteclick) //checks if the color of the vakje that is first clicked is the same as the color from the player
            {
                _eersteclick = false; 
                _tweedeclickcords = _bord.vak[x, y].coordinaten;
            }         

            if (vank.GetBepaal) //when set is legit, call the method VeranderKleur in class Vakje
            {
                vank.VeranderKleur(_bord._buffer, vank.coordinaten, vank.vakSize, _kleur); //sends information to aantalspelers
                
                if ((_eersteclickX + _eersteclickY) % CalculatedInt == _StartWaarde && vank.GetDubbelezet) //if the first clicked vakje is on an even number & Dubbulezet is true then make that vakje back to white
                {
                    oudvakje.ResetColor(_bord._buffer, oudvakje.coordinaten, oudvakje.vakSize, Brushes.White);
                }

                else if ((_eersteclickX + _eersteclickY) % CalculatedInt != _StartWaarde && vank.GetDubbelezet) //if the first clicked vakje is not on an even number & Dubbulezet is true then make that vakje back to black
                {
                    oudvakje.ResetColor(_bord._buffer, oudvakje.coordinaten, oudvakje.vakSize, Brushes.Black);
                }
                
                _Playerturn = !_Playerturn; //reverse the playerturn bool
                _eersteclick = true; //makes the zet int back to 0 so the next time you have to click again on the vakje you want to move
                vank.ResetBepaal();
            }                     
        }

        public void AiTurn() //Ai makes a move using this method
        {
            while (!_Playerturn)	//loop when it is not playerturn
            {
                _computer.MakeAMove(_eersteclick, _Playerturn, size, _StartWaarde);

                if (_computer.GetOutOfMoves)
                {
                    _Spelover();
                }

                Clicker(_computer.GetXcord, _computer.GetYcord);	//activate clicker method
            }

        }
    
		public void Restart(PictureBox box) //used to restart the application after the restart button is pressed
        {
            _bord.Maak(box);    //draws bord via public void maak
        }

		public void StartSpel(PictureBox box)
		{
			_bord.Maak(box);	//draws bord via public void maak
		}
	}
}
