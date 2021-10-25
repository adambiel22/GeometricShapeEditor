using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.Relations;

namespace Edytor.OnlyGeometry
{
    public class Edge : IDrawable, ISelectable, IRelatable
    {
        public PolygonVertex Start { get; set; }
        public PolygonVertex End { get; set; }
        public Polygon ParentPolygon { get; set; }
        public IRelation Relation { get; set; }

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

        public bool Move(Point p1, Point p2)
        {
            return RelationMover.MoveSetOfPolygonVericies(new List<PolygonVertex> { Start, End }, p1, p2);
        }

        public void Draw(Graphics g, DrawSettings drawSettings)
        {
            g.DrawEdge(Start, End, IsSelected ? drawSettings.SelectionColor : drawSettings.LineColor);
            if (Relation != null)
            {
                Relation.Draw(g, drawSettings);
            }
        }

        public void SetRelation(IRelation relation, bool ifRepare = true)
        {
            if (relation == null && Relation != null)
            {
                Relation.DisposeRelation();
                Relation = null;
                return;
            }
            if (relation == null) return;
            Relation = relation;
            if (ifRepare)
            {
                Stack<IRelation> S = new Stack<IRelation>();
                S.Push(relation);
                RelationMover.Recursion(new List<ISelectable>(), S);
            }
        }

        public bool IsRelationFullfiled()
        {
            return Relation == null || Relation.IsRelation();
        }
    }
}
