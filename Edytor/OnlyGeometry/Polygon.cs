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

        public int VerticesCount => vertices.Count;

        public Polygon(Point p1, Point p2, Scene scene)
        {
            edges = new List<Edge>();
            vertices = new List<PolygonVertex>();
            PolygonVertex vertex1 = new PolygonVertex(p1, this);
            PolygonVertex vertex2 = new PolygonVertex(p1, this);
            vertices.Add(vertex1);
            vertices.Add(vertex2);
            edges.Add(new Edge(vertex1, vertex2, this));
            edges.Add(new Edge(vertex2, vertex1, this));
        }

        public void DeleteVertex(PolygonVertex polygonVertex)
        {
            if (VerticesCount == 2)
            {
                parentScene.DeleteShape(this);
            }
            polygonVertex.PrevEdge.End = polygonVertex.NextEdge.End;
            edges.Remove(polygonVertex.NextEdge);
            vertices.Remove(polygonVertex);            
        }

        protected Scene parentScene;
        protected List<Edge> edges;
        protected List<PolygonVertex> vertices;
    }
}
