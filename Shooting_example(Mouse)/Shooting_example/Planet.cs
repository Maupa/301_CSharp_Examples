using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Shooting_example
{
    class Planet
    {
        // declare fields to use in the class

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

            g.DrawImage(planetImage, planetRec);
        }

        public int changesx
        {
            get
            {
                return x;
            }
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


        public void movePlanet()
        {
            planetRec.Location = new Point(x, y);
            if (planetRec.Location.Y > 400)
            {
                y = -20;
                planetRec.Location = new Point(x, y);
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
