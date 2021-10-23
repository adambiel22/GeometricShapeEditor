using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.Relations;

namespace Edytor.OnlyGeometry
{
    public class Edge
    {
        public PolygonVertex Start { get; set; }
        public PolygonVertex End { get; set; }
        public Polygon ParentPolygon { get; set; }
        public IRelation Relation { get; set; }

        public int Lenght => GeometryOperations.Distance(Start, End);

        public Edge(PolygonVertex s, PolygonVertex e, Polygon polygon)
        {
            Start = s;
            End = e;
            ParentPolygon = polygon;
        }
    }
}
