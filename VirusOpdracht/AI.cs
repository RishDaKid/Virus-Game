using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusOpdracht
{
    abstract class  AI 
    {
        private bool OutOfMoves;
        private int _xcord;
        private int _ycord;
        private Random _rnd = new Random(); //Random zet van de AI

        public AI()
        {
            OutOfMoves = false;
            _xcord = 0;
            _ycord = 0;
        }

        public void AiTurn(bool _eersteclick, bool _Playerturn, int size, int _StartWaarde) //Ai makes a move using this method
        {
            int count = 0;

            if (_eersteclick && !_Playerturn) //when it is the turn of the ai, keep looping through the vakjes until you have clicked on 1 of your own vakjes
            {
                _xcord++;
                if (_xcord == size)
                {
                    _xcord = _StartWaarde;
                    _ycord++;
                }

                if (_ycord == size)
                {
                    _ycord = _StartWaarde;
                }
            }

            if (!_eersteclick && !_Playerturn) //when the first click occured choose a random vakje to click on. Keep doing so until you have succesfully made a legal set
            {
                _xcord = _rnd.Next(size);
                _ycord = _rnd.Next(size);

                if (count == 50) //After 50 tries you have lost (This means the pc can't make any more moves)
                {
                    OutOfMoves = true;
                }
                count++;
            }
        }

        public bool GetOutOfMoves
        {
            get { return OutOfMoves; }
        }

        public int GetXcord
        {
            get { return _xcord; }
        }

        public int GetYcord
        {
            get { return _ycord; }
        }

    }
}
