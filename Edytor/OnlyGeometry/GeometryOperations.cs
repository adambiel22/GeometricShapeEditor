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
        
        public static void SetEdgeLenght(Edge edge, int lenght, bool moveStart)
        {
            int distance = edge.Lenght;
            if (moveStart)
            {
                edge.Start.Move(
                    new Point(0, 0),
                    new Point((edge.End.X - edge.Start.X) * (lenght - distance) / distance,
                        (edge.End.Y - edge.Start.Y) * (lenght - distance) / distance));
            }
            else
            {
                edge.End.Move(
                    new Point(0, 0),
                    new Point((edge.Start.X - edge.End.X) * (lenght - distance) / distance,
                        (edge.Start.Y - edge.End.Y) * (lenght - distance) / distance));
            }
            
        }
    }
}
