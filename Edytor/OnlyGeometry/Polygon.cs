using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.Relations;

namespace Edytor.OnlyGeometry
{
    public class Polygon : IShape
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
            vertex1.NextEdge = edges[0];
            vertex1.PrevEdge = edges[1];
            vertex2.NextEdge = edges[1];
            vertex2.PrevEdge = edges[0];
            parentScene = scene;
        }

        public void AddVertex(Point point)
        {
            PolygonVertex vertex = new PolygonVertex(point, this);
            Edge edge = new Edge(vertex, vertices[0], this);
            edges[^1].End = vertex;
            vertex.NextEdge = edge;
            vertex.PrevEdge = edges[^1];
            vertices[0].PrevEdge = edge;
            vertices.Add(vertex);
            edges.Add(edge);
        }

        public void AddVertex(int index, Point point)
        {
            PolygonVertex vertex = new PolygonVertex(point, this);
            Edge edge = new Edge(vertex, vertices[index % VerticesCount], this);
            edges[index - 1].End = vertex;
            vertex.NextEdge = edge;
            vertex.PrevEdge = edges[index - 1];
            vertices[index % VerticesCount].PrevEdge = edge;
            vertices.Insert(index, vertex);
            edges.Insert(index, edge);
        }

        public void SplitEdge(Edge edge)
        {
            int index = edges.IndexOf(edge);
            if (index < 0) return;
            if (edge.Relation != null)
                edge.Relation.DisposeRelation();
            AddVertex(index + 1,
                GeometryOperations.EdgeMiddle(edge));
        }

        public void DeleteVertex(PolygonVertex polygonVertex)
        {
            if (VerticesCount == 2)
            {
                parentScene.DeleteShape(this);
            }
            polygonVertex.PrevEdge.End = polygonVertex.NextEdge.End;
            if (polygonVertex.PrevEdge.Relation != null)
                polygonVertex.PrevEdge.Relation.DisposeRelation();
            polygonVertex.NextEdge.End.PrevEdge = polygonVertex.PrevEdge;
            if (polygonVertex.NextEdge.Relation != null)
                polygonVertex.NextEdge.Relation.DisposeRelation();
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
            if (vertices.Count == 2) return null;
            var polygon = new GraphicsPath();
            List<Point> points = new List<Point>();
            foreach (var vertex in vertices)
            {
                points.Add(new Point(vertex.X, vertex.Y));

            }
            polygon.AddPolygon(points.ToArray());
            if (polygon.IsVisible(point))
                return this;
            return null;
        }

        public void Delete()
        {
            foreach (Edge edge in edges)
            {
                if (edge.Relation != null)
                    edge.Relation.DisposeRelation();
            }
            parentScene.DeleteShape(this);
        }

        public void Move(Point p1, Point p2)
        {
            RelationMover.MoveSetOfPolygonVericies(new List<PolygonVertex>(vertices), p1, p2);
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
