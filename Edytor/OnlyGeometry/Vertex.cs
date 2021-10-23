using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class Vertex
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

        public void Move(Point start, Point end)
        {
            X += end.X - start.X;
            Y += end.Y - start.Y;
        }
    }
}
