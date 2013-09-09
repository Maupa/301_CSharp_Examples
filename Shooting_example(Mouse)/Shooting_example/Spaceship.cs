using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Shooting_example
{
    class Spaceship
    {
         private int x, y, width, height;//variables for the rectangle
        private Image spaceship;//variable for the spaceship's image

        private Rectangle spaceRec;//variable for a rectangle to place our image in
       
        //Create a constructor (initialises the values of the fields)
        public Spaceship()
        {
            x = 10;
            y = 350;
            width = 73;
            height = 39;
            spaceship = Properties.Resources.alien1;
            spaceRec = new Rectangle(x, y, width, height);
        }
        public Spaceship(Rectangle spaceRec)
        {
            x = spaceRec.X;
            y = spaceRec.Y;
            width = 73;
            height = 39;
            spaceship = Properties.Resources.alien1;
            spaceRec = new Rectangle(x, y, width, height);
        }
        public void drawSpaceship(Graphics g)
        {
           
            g.DrawImage(spaceship, spaceRec);
        }

         public void moveSpaceship(int mouseX)
        {
            spaceRec.X = mouseX - (spaceRec.Width/2);
             
        }

         public Rectangle SpaceRec
         {
             get
             {
                 return spaceRec;
             }
         }

    }
 }


