using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class MidPoint : Vertex
    {
        public MidPoint(Point p, Circle circle) : base(p)
        {
            parentCircle = circle;
        }

        public MidPoint(int x, int y, Circle circle) : base(x, y)
        {
            parentCircle = circle;
        }

        public override void Delete()
        {
            parentCircle.Delete();
        }

        private Circle parentCircle;
    }
}
