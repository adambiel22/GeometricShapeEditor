using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Edytor.OnlyGeometry
{
    public class GeometryOperations
    {
        public static int Distance(Vertex v1, Vertex v2)
        {
            return (int)Math.Sqrt((v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y));
        }

        public static int Distance(Point v1, Point v2)
        {
            return (int)Math.Sqrt((v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y));
        }

        public static int DistanceSquare(Vertex v1, Vertex v2)
        {
            return (v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y);
        }
        
        public static void SetEdgeLength(Edge edge, int length, bool moveStart)
        {
            int distance = edge.Length;
            if (moveStart)
            {
                AddVectorToVertex(edge.Start,
                    new Point(0, 0),
                    new Point((edge.End.X - edge.Start.X) * (distance - length) / distance,
                        (edge.End.Y - edge.Start.Y) * (distance - length) / distance));
            }
            else
            {
                AddVectorToVertex(edge.End,
                    new Point(0, 0),
                    new Point((edge.Start.X - edge.End.X) * (distance - length) / distance,
                        (edge.Start.Y - edge.End.Y) * (distance - length) / distance));
            }
        }

        public static void SetEdgeDirection(Edge edge, Edge direcrtionEdge, bool moveStart)
        {
            if (direcrtionEdge.Start.X == direcrtionEdge.End.X)
            {
                if (moveStart)
                {
                    edge.Start.X = edge.End.X;
                }
                else
                {
                    edge.End.X = edge.Start.X;
                }
                return;
            }
            double B = 1000 * (direcrtionEdge.Start.Y - direcrtionEdge.End.Y) /
                (direcrtionEdge.Start.X - direcrtionEdge.End.X);
            double A = 1000;
            double r = A * A + B * B;
            if (moveStart)
            {
                double s = (edge.Start.X - edge.End.X) * A + B * (edge.Start.Y - edge.End.Y);
                AddVectorToVertex(edge.Start, new Point(edge.Start.X, edge.Start.Y),
                    new Point((int)Math.Ceiling(edge.End.X + A * s / r), (int)Math.Ceiling(edge.End.Y + B * s / r)));
            }
            else
            {
                double s = (edge.Start.X - edge.End.X) * A + B * (edge.Start.Y - edge.End.Y);
                AddVectorToVertex(edge.End, new Point(edge.End.X, edge.End.Y),
                    new Point((int)(edge.Start.X + A * s / r), (int)(edge.Start.Y + B * s / r)));
            }
        }

        public static Point EdgeMiddle(Edge edge)
        {
            return new Point((edge.Start.X + edge.End.X) / 2, (edge.Start.Y + edge.End.Y) / 2);
        }

        public static void AddVectorToVertex(Vertex vertex, Point start, Point end)
        {
            vertex.X += end.X - start.X;
            vertex.Y += end.Y - start.Y;
        }
    }
}
