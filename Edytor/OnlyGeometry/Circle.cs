using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class Circle
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
    }
}
