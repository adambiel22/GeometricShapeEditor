using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.Relations;

namespace Edytor.OnlyGeometry
{
    public class Edge : IDrawable, ISelectable
    {
        public PolygonVertex Start { get; set; }
        public PolygonVertex End { get; set; }
        public Polygon ParentPolygon { get; set; }
        public IRelation Relation { get; set; }

        public int Lenght => GeometryOperations.Distance(Start, End);

        public bool IsSelected { get; set; }

        public Edge(PolygonVertex s, PolygonVertex e, Polygon polygon)
        {
            Start = s;
            End = e;
            ParentPolygon = polygon;
        }

        public ISelectable Select(Point point)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            ParentPolygon.DeleteVertex(Start);
            ParentPolygon.DeleteVertex(End);
        }

        public void Move(Point p1, Point p2)
        {
            Start.Move(p1, p2);
            End.Move(p1, p2);
        }

        public void Draw(Graphics g)
        {
            g.DrawEdge(Start, End);
        }
    }
}
