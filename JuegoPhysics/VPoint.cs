using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Billar
{
    public class VPoint
    {
        bool isPinned = false;
        bool fromBody = false;
        public Vec2 pos, old, vel, gravity;
        public int id;
        public float Mass;
        float radius, bounce, diameter, m, frict = 0.99f;
        float groundFriction = 0.7f;
        Color c;
        SolidBrush brush;
        public int tableHolesSize;
        Random random = new Random();
        public bool isWhite;
        int x;


        public bool FromBody
        {
            get { return fromBody; }
            set { fromBody = value; }
        }
        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool IsPinned
        {
            get { return isPinned; }
            set { isPinned = value; }
        }
        public float X
        {
            get { return pos.X; }
            set { pos.X = value; }
        }
        public float Y
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }
        public Vec2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Vec2 Old
        {
            get { return old; }
            set { old = value; }
        }
        public float Radius
        {
            get { return radius; }
            set { radius = value; diameter = radius + radius; }
        }

        public VPoint(int x, int y, int id, int tableHolesSize)
        {
            this.id = id;
            this.pos = new Vec2(x, y);
            this.radius = 20;
            this.tableHolesSize = tableHolesSize;
            Init(x, y, 0, 0);
        }


        private void Init(int x, int y, float vx, float vy)
        {
            pos = new Vec2(x, y);
            old = new Vec2(x, y);
            gravity = new Vec2(0, 0);
            vel = new Vec2(vx, vy);
            radius = 20;
            diameter = radius + radius;
            Mass = 1f;
            bounce = 1f;

            if(this.id == 0)
            {
                brush = new SolidBrush(Color.Yellow);
            }
            else if (this.id == 14)
            {
                brush = new SolidBrush(Color.White); //rayada amarilla 14
            }
            else if(this.id == 1)
            {
                brush = new SolidBrush(Color.White); //rayada azul 1
            }
            else if (this.id == 7)
            {
                brush = new SolidBrush(Color.Blue);
            }
            else if(this.id == 8)
            {
                brush = new SolidBrush(Color.White); // rayada roja 8
            }
            else if (this.id == 2)
            {
                brush = new SolidBrush(Color.Red);
            }
            else if(this.id == 3)
            {
                brush= new SolidBrush(Color.White); // rayada morada 3
            }
            else if (this.id == 9)
            {
                brush = new SolidBrush(Color.Purple);
            }
            else if(this.id == 11)
            {
                brush = new SolidBrush(Color.White); // rayada naranja 11
            }
            else if (this.id == 4)
            {
                brush = new SolidBrush(Color.Orange);
            }
            else if (this.id == 5)
            {
                brush= new SolidBrush(Color.White); // rayada verde 5
            }
            else if (this.id == 12)
            {
                brush = new SolidBrush(Color.LightGreen);
            }
            else if(this.id == 13)
            {
                brush= new SolidBrush(Color.White); // rayada roja indio 13
            }
             else if(this.id == 6)
            {
                brush= new SolidBrush(Color.IndianRed);
            }
            else if(this.id == 15) 
            {
                brush = new SolidBrush(Color.White);
            }
            else if(this.id == 10)
            {
                brush = new SolidBrush(Color.Black);
            }


        }

            public void Update(int width, int height)
        {
            vel = (pos - old) * frict;

            old = pos;
            pos += vel + gravity;
        }

        public void Constraints(int width, int height)
        {
            if (pos.X < radius) {
                pos.X = radius;
                old.X = (pos.X + vel.X);
            }
            if (pos.X > width - radius) {
                pos.X = width - radius;
                old.X = (pos.X + vel.X);
            }
            if (pos.Y < radius) {
                pos.Y = radius;
                old.Y = (pos.Y + vel.Y);
            }
            if (pos.Y > height - radius) {
                pos.Y = height - radius;
                old.Y = (pos.Y + vel.Y);
            }

            if ((pos.X - radius) <= tableHolesSize || (pos.X + radius) >= width - tableHolesSize)
            {
                if (pos.X - radius <= tableHolesSize)
                {
                    pos.X = (tableHolesSize + radius);
                    old.X = (pos.X + vel.X);
                }
                else
                {
                    pos.X = (width - tableHolesSize) - radius;
                    old.X = (pos.X + vel.X);
                }
            }

            if ((pos.Y - radius) <= tableHolesSize || (pos.Y + radius) >= height - tableHolesSize)
            {
                if (pos.Y - radius <= tableHolesSize)
                {
                    pos.Y = (tableHolesSize + radius);
                    old.Y = (pos.Y + vel.Y);
                }
                else
                {
                    pos.Y = (height - tableHolesSize) - radius;
                    old.Y = (pos.Y + vel.Y);
                }
            }
        }

        public void Render(Graphics g, int width, int height)
        {
            Pen penY = new Pen(Color.Yellow, 10);
            Pen penB = new Pen(Color.Blue, 10);
            Pen penR = new Pen(Color.Red, 10);
            Pen penP = new Pen(Color.Purple, 10);
            Pen penO = new Pen(Color.Orange, 10);
            Pen penG = new Pen(Color.LightGreen, 10);
            Pen penR1 = new Pen(Color.IndianRed, 10);

            Update(width, height);
            Constraints(width, height);

            g.FillEllipse(brush, pos.X - radius, pos.Y - radius, diameter, diameter);

            if(this.id == 14)
            {
                g.DrawLine(penY, pos.X - radius, (pos.Y - radius) + diameter / 2, (pos.X - radius) + diameter, (pos.Y - radius) + diameter / 2);
            }else if(this.id == 8)
            {
                g.DrawLine(penR, pos.X - radius, (pos.Y - radius) + diameter / 2, (pos.X - radius) + diameter, (pos.Y - radius) + diameter / 2);
            }else if(this.id == 3)
            {
                g.DrawLine(penP, pos.X - radius, (pos.Y - radius) + diameter / 2, (pos.X - radius) + diameter, (pos.Y - radius) + diameter / 2);
            }else if(this.id == 1)
            {
                g.DrawLine(penB, pos.X - radius, (pos.Y - radius) + diameter / 2, (pos.X - radius) + diameter, (pos.Y - radius) + diameter / 2);
            }else if(this.id == 11)
            {
                g.DrawLine(penO, pos.X - radius, (pos.Y - radius) + diameter / 2, (pos.X - radius) + diameter, (pos.Y - radius) + diameter / 2);
            }else if(this.id == 5)
            {
                g.DrawLine(penG, pos.X - radius, (pos.Y - radius) + diameter / 2, (pos.X - radius) + diameter, (pos.Y - radius) + diameter / 2);
            }else if(this.id == 13)
            {
                g.DrawLine(penR1, pos.X - radius, (pos.Y - radius) + diameter / 2, (pos.X - radius) + diameter, (pos.Y - radius) + diameter / 2);
            }
                
        }
    }
}
