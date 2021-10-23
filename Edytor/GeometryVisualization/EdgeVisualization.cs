using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.OnlyGeometry;

namespace Edytor.GeometryVisualization
{
    public class EdgeVisualization : Edge, IDrawable, ISelectable
    {
        public EdgeVisualization(PolygonVertex s, PolygonVertex e, Polygon polygon) : base(s, e, polygon)
        {
        }

        public bool IsSelected { get; set; }

        public void Delete()
        {
            ParentPolygon.DeleteVertex(Start);
            ParentPolygon.DeleteVertex(End);
        }

        public void Draw(Graphics g)
        {
            g.DrawEdge(Start, End);
        }

        public void Move(Point p1, Point p2)
        {
            throw new NotImplementedException();
        }

        public ISelectable Select()
        {
            throw new NotImplementedException();
        }
    }
}
