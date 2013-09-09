using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Test_Classes_Dodge
{
    class Planet
    {
        // declare fields to use in the class
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        private int x, y, width, height;//variables for the rectangle
        private Image planetImage;//variable for the planet's image

        private Rectangle planetRec;//variable for a rectangle to place our image in
       
        //Create a constructor (initialises the values of the fields)
        public Planet()
        {
            x = 10;
            y = 10;
            width = 20;
            height = 20;
            planetImage = Properties.Resources.planet1;
            planetRec = new Rectangle(x, y, width, height);
        }
        // Methods for the Planet class
        public void drawPlanet(Graphics g)
        {
            planetRec = new Rectangle(x, y, width, height);
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, (byte)GetRandomNumber(0, 255), (byte)GetRandomNumber(0, 255), (byte)GetRandomNumber(0, 255))), 0, 0, width, height);
       
        }
        public void movePlanet()
        {
            planetRec.Location = new Point(x, y);
            if (planetRec.Location.Y > 400)
            {
                score += 1;// add 1 to score when planet reaches bottom of panel
                y = 20;
                planetRec.Location = new Point(x, y);
            }

        }

        //Property to set the x position of planetRec from the form
        public int changesx
        {
            set
            {
                x = value;
            }
        }
        public int changesy
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        // property to pass score back to form to display  
        private int score;
        public int planetScore
        {
            get
            {
                return score;
            }
        }
        //property to read planetRec from the form to check for
        // a collision with the space rectangle in the tmrPlanet event
        public Rectangle PlanetRec
        {
            get
            {
                return planetRec;
            }
        }

    }
}
