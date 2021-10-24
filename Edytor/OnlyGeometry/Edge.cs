using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.Relations;

namespace Edytor.OnlyGeometry
{
    public class Edge : IDrawable, ISelectable
    {
        public PolygonVertex Start { get; set; }
        public PolygonVertex End { get; set; }
        public Polygon ParentPolygon { get; set; }
        public IRelation Relation { get; protected set; }

        public int Length => GeometryOperations.Distance(Start, End);

        public bool IsSelected { get; set; }

        public Edge(PolygonVertex s, PolygonVertex e, Polygon polygon)
        {
            Start = s;
            End = e;
            ParentPolygon = polygon;
        }

        public ISelectable Select(Point point)
        {
            if (point.X >= Math.Min(Start.X, End.X) - 4 && point.X <= Math.Max(Start.X, End.X) + 4 &&
                point.Y >= Math.Min(Start.Y, End.Y) - 4 && point.Y <= Math.Max(Start.Y, End.Y) + 4 &&
                Math.Abs((Start.Y - End.Y) * point.X + (End.X - Start.X) * point.Y + Start.X * (End.Y - Start.Y) - Start.Y * (End.X - Start.X)) /
                Math.Sqrt((Start.Y - End.Y) * (Start.Y - End.Y) + (End.X - Start.X) * (End.X - Start.X)) <= 5)
                return this;
            return null;

        }

        public void Delete()
        {
            ParentPolygon.DeleteVertex(Start);
            ParentPolygon.DeleteVertex(End);
        }

        public void Move(Point p1, Point p2)
        {
            RelationMover.MoveSetOfPolygonVericies(new List<PolygonVertex> { Start, End }, p1, p2);
        }

        public void Draw(Graphics g)
        {
            g.DrawEdge(Start, End);
            if (Relation != null)
            {
                Relation.Draw(g);
            }
        }

        public void SetRelation(IRelation relation)
        {
            Relation = relation;
            if (relation == null) return;
            Stack<IRelation> S = new Stack<IRelation>();
            S.Push(relation);
            RelationMover.Recursion(new List<PolygonVertex>(), S);
        }

        public bool IsRelationFullfiled()
        {
            return Relation == null || Relation.IsRelation();
        }
    }
}
