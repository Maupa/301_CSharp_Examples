using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Shooting_example
{
    class Missile
    {
          int x, y, width, height;

        private Image missile;//variable for the bullet's image

        private Rectangle missileRec;//variable for a rectangle to place our image in

         public Missile(Rectangle spaceRec)
        {
            x = spaceRec.X + 30;
            y = spaceRec.Y;
            width = 13;
            height = 30;
            missile = Properties.Resources.missile;
           missileRec = new Rectangle(x, y, width, height);
        }

        public void draw(Graphics g)
        {
            y -= 20;
           missileRec = new Rectangle(x, y, width, height);
            g.DrawImage(missile,missileRec);
        }
        //Property

        public Rectangle MissileRec
        {
            get
            {
                return missileRec;
            }
        }
    }
}
