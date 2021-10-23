using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.Geometry
{
    public class Vertex : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Vertex(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void DrawShape(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black), new Rectangle(X - 2, Y - 2, 4, 4));
        }

        public void Move(Point start, Point end)
        {
            X += end.X - start.X;
            Y += end.Y - start.Y;
        }

        public IDrawable Hit(Point point)
        {
            if ((point.X - X) * (point.X - X) + (point.Y - Y) * (point.Y - Y) <= 25)
            {
                return this;
            }
            return null;
        }

        public void Delete()
        {
            //Polygon.verices.Remeve();
        }
    }
}
