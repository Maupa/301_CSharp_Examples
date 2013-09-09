using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Classes_Dodge
{
    public partial class Form1 : Form
    {

        Graphics g; //declare a graphics object called g
        // declare space for an array of 7 objects called planet 
        Planet[] planet = new Planet[7];
        Random yspeed = new Random();
        Spaceship spaceship = new Spaceship();
        bool left, right;
        int score, lives;
        string move;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                planet[i] = new Planet();
            }

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Planet class's DrawPlanet method to draw the image planet1 
            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 70);
                planet[i].changesx = x;
                // generate a random number from 2 to 10 and put it in test
                int test = yspeed.Next(2, 10);
                planet[i].changesy += test; 

                //call the Planet class's drawPlanet method to draw the images
                planet[i].drawPlanet(g);
            }

            spaceship.drawSpaceship(g); 
        }

        private void tmrPlanet_Tick(object sender, EventArgs e)
        {
            score = 0; 
            for (int i = 0; i < 7; i++)
            {
                planet[i].movePlanet();
                if (spaceship.SpaceRec.IntersectsWith(planet[i].PlanetRec))
                {
                    //reset planet[i] back to top of panel
                    planet[i].changesy = 30; // set (write)  y value of planetRec (in drawPlanet method)
                    lives -= 1;// lose a life
                    txtLives.Text = lives.ToString();// display number of lives
                    checkLives();//check to see if game over
                }

                score += planet[i].planetScore;// get score from Planet class (in movePlanet method)
                lblScore.Text = score.ToString();// display score

            }

            pnlGame.Invalidate();//makes the paint event fire to redraw the panel
        }
      

  

   private void tmrShip_Tick(object sender, EventArgs e)
   {
     
       if (right) // if right arrow key pressed
       {
           move = "right";
           spaceship.moveSpaceship(move);
       }
       if (left) // if left arrow key pressed
       {
           move = "left";
           spaceship.moveSpaceship(move);
       }


   }

   private void Form1_KeyDown(object sender, KeyEventArgs e)
   {
       if (e.KeyData == Keys.Left) { left = true; }
       if (e.KeyData == Keys.Right) { right = true; }
   }

   private void Form1_KeyUp(object sender, KeyEventArgs e)
   {
       if (e.KeyData == Keys.Left) { left = false; }
       if (e.KeyData == Keys.Right) { right = false; }
   }

   private void checkLives()
   {
       if (lives == 0)
       {
           tmrPlanet.Enabled = false;
           tmrShip.Enabled = false;
           MessageBox.Show("Game Over");

       }
   }

   private void mnuStart_Click(object sender, EventArgs e)
   {
       score = 0;
       lblScore.Text = score.ToString();
       lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
       tmrPlanet.Enabled = true;
       tmrShip.Enabled = true;

   }

   private void mnuStop_Click(object sender, EventArgs e)
   {
       tmrShip.Enabled = false;
       tmrPlanet.Enabled = false;

   }

   private void Form1_Load(object sender, EventArgs e)
   {
       MessageBox.Show("Use the left and right arrow keys to move the spaceship. \n Don't get hit by the planets! \n Every planet that gets past scores a point. \n If a planet hits a spaceship a life is lost! \n \n Enter your Name press tab and enter the number of lives \n Click Start to begin", "Game Instructions");
       txtName.Focus();



   }



    }

    }

