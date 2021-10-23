using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public abstract class Vertex : IDrawable, ISelectable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsSelected { get; set; }

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

        public void Move(Point start, Point end)
        {
            X += end.X - start.X;
            Y += end.Y - start.Y;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(X - 2, Y - 2, 4, 4));
        }

        public ISelectable Select(Point point)
        {
            if ((point.X - X) * (point.X - X) + (point.Y - Y) * (point.Y - Y) <= 25) //sparametryzować to!
            {
                return this;
            }
            return null;
        }
        public abstract void Delete();
    }
}
