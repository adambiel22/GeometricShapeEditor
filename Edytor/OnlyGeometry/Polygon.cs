using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class Polygon : IDrawable, ISelectable
    {

        public int VerticesCount => vertices.Count;

        public bool IsSelected { get; set; }

        public Polygon(Point p1, Point p2, Scene scene)
        {
            edges = new List<Edge>();
            vertices = new List<PolygonVertex>();
            PolygonVertex vertex1 = new PolygonVertex(p1, this);
            PolygonVertex vertex2 = new PolygonVertex(p2, this);
            vertices.Add(vertex1);
            vertices.Add(vertex2);
            edges.Add(new Edge(vertex1, vertex2, this));
            edges.Add(new Edge(vertex2, vertex1, this));
        }

        public void AddVertex(Point point)
        {
            PolygonVertex vertex = new PolygonVertex(point, this);
            Edge edge = new Edge(vertex, vertices[0], this);
            edges[^1].End = vertex;
            vertices.Add(vertex);
            edges.Add(edge);
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

        public void MoveVertex(int i, Point p)
        {
            vertices[i].X = p.X;
            vertices[i].Y = p.Y;
        }

        public ISelectable Select(Point point)
        {
            ISelectable selectable;
            foreach (Vertex vertex in vertices)
            {
                selectable = vertex.Select(point);
                if (selectable != null)
                {
                    return selectable;
                }
            }
            foreach (Edge edge in edges)
            {
                selectable = edge.Select(point);
                if (selectable != null)
                {
                    return selectable;
                }
            }
            // czy trafiło w środek wielokąta
            return null;
        }

        public void Delete()
        {
            parentScene.DeleteShape(this);
        }

        public void Move(Point p1, Point p2)
        {
            foreach (var vertex in vertices)
            {
                vertex.Move(p1, p2);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Vertex vertex in vertices)
            {
                vertex.Draw(g);
            }
            foreach (Edge edge in edges)
            {
                edge.Draw(g);
            }
        }

        private Scene parentScene;
        private List<Edge> edges;
        private List<PolygonVertex> vertices;
    }
}
