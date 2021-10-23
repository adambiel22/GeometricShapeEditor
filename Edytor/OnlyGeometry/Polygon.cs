using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class Polygon
    {

        private List<Edge> edges { get; set; }
        private List<PolygonVertex> vertices { get; set; }

        public int VerticesCount => vertices.Count;

        public Polygon(Point p1, Point p2)
        {
            edges = new List<Edge>();
            vertices = new List<PolygonVertex>();
            vertices.Add(new PolygonVertex(p1, this));
            vertices.Add(new PolygonVertex(p2, this));
        }
    }
}
