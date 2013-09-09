using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shooting_example
{
    public partial class Form1 : Form
    {
        Graphics g; //declare a graphics object called g
        Spaceship spaceship = new Spaceship();//create object called spaceship 
        //declare a list  missiles from the missile class
        List<Missile> missiles = new List<Missile>();
        int score;
        Planet[] planet = new Planet[7];
        Random yspeed = new Random();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                planet[i] = new Planet();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
           g = e.Graphics;
           spaceship.drawSpaceship(g);
           foreach (Missile missile in missiles)
           {
               missile.draw(g);
           }
           //call the Planet class's DrawPlanet method to draw the image planet1 
           for (int i = 0; i < 7; i++)
           {

               int x = 10 + (i * 70);
               planet[i].changesx = x;
               int test = yspeed.Next(2, 10);
               planet[i].changesy += test;


               //call the Planet class's drawPlanet method to draw the images
               planet[i].drawPlanet(g);
           }
       
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            spaceship.moveSpaceship(e.X);
            //this.Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                missiles.Add(new Missile(spaceship.SpaceRec));
            }
        }

        private void tmrShoot_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
            if (planet[i].changesy > this.Height)
            {
                planet[i].changesy = -30;
            }
            foreach (Missile m in missiles)
            {
                if (m.MissileRec.IntersectsWith(planet[i].PlanetRec))
                {
                    planet[i].changesy = -30; // set (write) y value of planetRec (in drawPlanet method)
                    score += 1;
                    missiles.Remove(m);
                    break;
                }
            }
            }

          
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    
    }
}
