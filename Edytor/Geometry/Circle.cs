using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.Geometry
{
    public class Circle : IDrawable
    {
        public Vertex MidPoint { get; set; }
        public int R { get; set; }

        public Circle(Vertex mid, int r)
        {
            MidPoint = mid;
            R = r;
        }
        public Circle(Point mid, int r)
        {
            MidPoint = new Vertex(mid);
            R = r;
        }

        public void DrawShape(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black), new Rectangle(MidPoint.X - R, MidPoint.Y - R, 2 * R, 2 * R));
        }

        public void Move(Point start, Point end)
        {
            R = (int)Math.Sqrt((MidPoint.X - end.X) * (MidPoint.X - end.X) + (MidPoint.Y - end.Y) * (MidPoint.Y - end.Y));
        }

        public IDrawable Hit(Point point)
        {
            int r = (int)Math.Sqrt((MidPoint.X - point.X) * (MidPoint.X - point.X)
                + (MidPoint.Y - point.Y) * (MidPoint.Y - point.Y));
            if (R - 4 <= r && r <= R + 4)
            {
                return this;
            }
            else if (r < R)
            {
                return MidPoint;
            }
            return null;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
