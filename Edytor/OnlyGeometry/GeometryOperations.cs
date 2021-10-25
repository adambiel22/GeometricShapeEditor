using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Edytor.Relations;

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

        public static int Distance(Edge edge, Point point)
        {
            int A = (edge.Start.Y - edge.End.Y);
            int B = (edge.End.X - edge.Start.X);
            int C = edge.Start.Y * (edge.Start.X - edge.End.X) +
                    edge.Start.X * (edge.End.Y - edge.Start.Y);
            return (int)(Math.Abs(point.X * A + point.Y * B - C) / Math.Sqrt(A * A + B * B));
        }

        public static int Distance(Point Start, Point End, Point point)
        {
            int A = (Start.Y - End.Y);
            int B = (End.X - Start.X);
            int C = Start.Y * (Start.X - End.X) +
                    Start.X * (End.Y - Start.Y);
            return (int)(Math.Abs(point.X * A + point.Y * B - C) / Math.Sqrt(A * A + B * B));
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

        public static void SetEdgeDirection(Edge edge, Edge directionEdge, bool moveStart)
        {
            if (directionEdge.Start.X == directionEdge.End.X)
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
            double B = 1000 * (directionEdge.Start.Y - directionEdge.End.Y) /
                (directionEdge.Start.X - directionEdge.End.X);
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

        public static bool MakeEdgeTangentialToCircle(Edge edge, Circle circle, bool moveStart)
        {
            int x = moveStart ? edge.End.X : edge.Start.X;
            int y = moveStart ? edge.End.Y : edge.Start.Y;
            Vertex movedVertex = moveStart ? edge.Start : edge.End;
            Point p = new Point(movedVertex.X, movedVertex.Y);
            int a = circle.Mid.X * circle.Mid.X + x * x - 2 * x * circle.Mid.X - 
                circle.R * circle.R;
            int b = 2 * (-x * y + circle.Mid.X * y - circle.Mid.X * circle.Mid.Y + 
                circle.Mid.Y * x);
            int c = circle.Mid.Y * circle.Mid.Y + y * y - 2 * circle.Mid.Y * y - circle.R * circle.R;

            double delta = b * b - 4 * a * c;
            if (delta < 0) return false;

            Point p1;
            Point p2;
            if (a == 0)
            {
                p1 = new Point(x, circle.Mid.Y);
                int A = (circle.Mid.Y - y) / (circle.Mid.X - x);
                int B = circle.Mid.Y - A * circle.Mid.X;
                int d = (int)(2*Math.Abs(A * p1.X - p1.Y + B) / Math.Sqrt(A * A + B * B));
                int x_1 = x < circle.Mid.X ? 10000 : -10000;
                int y_1 = x < circle.Mid.X ? -10000 / A : 1000 / A; 
                int d_1 = Distance(new Point(0, 0), new Point(x_1, y_1));
                p2 = new Point(x + (x_1 * d) / d_1, circle.Mid.Y + (y_1 * d) / d_1);

            }
            else
            {
                double a_1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double a_2 = (-b + Math.Sqrt(delta)) / (2 * a);
                double b_1 = y - a_1 * x;
                double b_2 = y - a_2 * x;
                p1 = new Point(x + 100, (int)(b_1 + a_1 * (x + 100)));
                p2 = new Point(x + 100, (int)(b_2 + a_2 * (x + 100)));
            }
            if (Distance(new Point(x, y), p1, p) <
                Distance(new Point(x, y), p2, p))
            {
                SetEdgeDirection(edge,
                    new Edge(new PolygonVertex(x, y, null),
                    new PolygonVertex(p1, null), null), moveStart);
            }
            else
            {
                SetEdgeDirection(edge,
                    new Edge(new PolygonVertex(x, y, null),
                    new PolygonVertex(p2, null), null), moveStart);
            }
            return true;
        }
        public static bool ChangeCircleRadiusToBeTangentialToEdge(Circle circle, Edge edge)
        {
            if ((circle.ReflexiveRelation as FixedRadiusRelation) != null)
                return false;
            circle.R = Distance(edge, new Point(circle.Mid.X, circle.Mid.Y));
            return true;
        }

        public static bool MoveCircleToBeTangentialToEdge(Circle circle, Edge edge)
        {
            if ((circle.ReflexiveRelation as FixedMidPointRelation) != null)
                return false;

            int A = (edge.Start.Y - edge.End.Y);
            int B = (edge.End.X - edge.Start.X);
            int C = edge.Start.Y * (edge.Start.X - edge.End.X) +
                    edge.Start.X * (edge.End.Y - edge.Start.Y);
            int d = Distance(edge, new Point(circle.Mid.X, circle.Mid.Y));
            if (B == 0 && circle.Mid.X <= edge.End.X)
            {
                circle.Mid.X = edge.End.X - circle.R;
                return true;
            }
            else if (B == 0 && circle.Mid.X > edge.End.X)
            {
                circle.Mid.X = edge.End.X + circle.R;
                return true;
            }
            bool isAbove = true;
            if (edge.Start.X < edge.End.X)
            {
                if (A * circle.Mid.X + B * circle.Mid.Y + C < 0)
                    isAbove = false;
            }
            else
            {
                if (A * circle.Mid.X + B * circle.Mid.Y + C > 0)
                    isAbove = false;
            }
            int x, y;
            if (isAbove)
            {
                x = -1000*A/B;
                y = -1000;

            }
            else
            {
                x = 1000 * A / B;
                y = 1000;
            }
            int dis = Distance(new Point(0, 0), new Point(x, y));
            circle.Mid.X += x * (d - circle.R) / dis;
            circle.Mid.Y += y * (d - circle.R) / dis;
            return true;
        }
    }
}
