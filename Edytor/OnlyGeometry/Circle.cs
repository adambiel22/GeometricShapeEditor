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
        public Scene ParentScene { get; set; }

        public Circle(Vertex mid, int r, Scene parentScene)
        {
            MidPoint = mid;
            R = r;
            ParentScene = parentScene;
        }
        public Circle(Point mid, int r, Scene parentScene)
        {
            //MidPoint = new Vertex(mid);
            R = r;
            ParentScene = parentScene;
        }
    }
}
