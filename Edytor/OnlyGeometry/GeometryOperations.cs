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
