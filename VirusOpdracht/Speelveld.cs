using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusOpdracht
{
	public partial class Speelveld : Form
	{
		Spel spel = new Spel(); //associatie met spel
        public Speelveld()
		{
			InitializeComponent();
			spel.StartSpel(pbMain);	//starts startspel Classe
        }


        private void BtnRestart_Click(object sender, EventArgs e)
        {
            spel.StartSpel(pbMain); //When the restart button is pressed the form will call the restart method in class Spel
        }

		private void PbMain_MouseClick(object sender, MouseEventArgs e)
		{
            double _x; //gets the x coordinate when mouseclick happens private double
            double _y; //gets the x coordinate when mouseclick happens private double
            _x = Math.Floor((double)e.X / 50);	//gets the y coordinate when mouseclick happens
			_y = Math.Floor((double)e.Y / 50);	//gets the x coodinate when mouseclick happens

			spel.Clicker((int)_x, (int)_y); //When a vakje has been pressed form will call the method Clicker in class Spel
			pbMain.Refresh();   //refreshes the pb
            spel.Score();
            SetScore();
            spel.CheckIfGameover();
            spel.AiTurn();
            pbMain.Refresh();
            spel.Score();
            SetScore();
            spel.CheckIfGameover();
		}

        public void SetScore() //Updates the scores on the form. Sets the number equel to the actual calculated score
        {
            lblPointsPlayer.Text = Convert.ToString(spel.GetScorePlayer); //used for the player score
            lblPointsAI.Text = Convert.ToString(spel.GetScoreAI); //used for the ai score
        }

        private void Speelveld_Load(object sender, EventArgs e)
        {

        }
    }
}