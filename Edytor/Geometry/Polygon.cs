using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.Geometry
{
    public class Polygon : IDrawable
    {
        private enum SelectedType
        {
            Vertex,
            Edge,
            Polygon
        }

        private List<Edge> edges { get; set; }
        private List<Vertex> vertices { get; set; }

        private int index;
        private SelectedType selectedType;

        public int VerticesCount => vertices.Count;

        public Polygon(Edge e)
        {
            edges = new List<Edge>();
            edges.Add(e);
            edges.Add(new Edge(e.End, e.Start));
            vertices = new List<Vertex>();
            vertices.Add(e.Start);
            vertices.Add(e.End);
        }

        public void DrawShape(Graphics g)
        {
            foreach(Edge edge in edges)
            {
                edge.DrawShape(g);
            }
        }

        public void AddVertex(Vertex p)
        {
            edges[^1].End = p;
            edges.Add(new Edge(p, vertices[0]));
            vertices.Add(p);
        }

        public void MoveVertex(int i, Point p)
        {
            vertices[i].X = p.X;
            vertices[i].Y = p.Y;
        }

        public void Move(Point start, Point end)
        {
            switch (selectedType)
            {
                case SelectedType.Vertex:
                    vertices[index].Move(start, end);
                    break;
                case SelectedType.Edge:
                    edges[index].Move(start, end);
                    break;
                case SelectedType.Polygon:
                    break;
                default:
                    break;
            }
        }

        public IDrawable Hit(Point point)
        {
            for (int i = 0; i < VerticesCount; i++) 
            {
                IDrawable vertex = vertices[i].Hit(point);
                if (vertex != null)
                {
                    return vertex;
                }
            }
            for (int i = 0; i < VerticesCount; i++)
            {
                Edge edge = (Edge)edges[i].Hit(point);
                if (edge != null)
                {
                    selectedType = SelectedType.Edge;
                    index = i;
                    return this;
                }
            }
            //sprawdzenie czy trafiłem w środek
            return null;
        }

        public void Delete()
        {
            switch (selectedType)
            {
                case SelectedType.Vertex:
                    vertices.RemoveAt(index);
                    if (!(index == 0))
                    {
                        edges.RemoveAt(index);
                        edges.RemoveAt(index - 1);
                        edges.Add(new Edge(vertices[index - 1], vertices[index]));
                    }
                    else
                    {
                        edges.RemoveAt(VerticesCount - 1);
                        edges.RemoveAt(0);
                        edges.Add(new Edge(vertices[VerticesCount - 1], vertices[0]));
                    }
                    break;
                case SelectedType.Edge:
                    break;
                case SelectedType.Polygon:
                    break;
                default:
                    break;
            }
        }
    }
}
