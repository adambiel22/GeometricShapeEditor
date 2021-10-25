using Edytor.OnlyGeometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.Relations
{
    public class TangentialRelation : IRelation
    {
        public Edge RelatedEdge { get; set; }
        public Circle RelatedCircle { get; set; }

        public TangentialRelation(Edge edge, Circle circle)
        {
            RelatedEdge = edge;
            RelatedCircle = circle;
        }
        public void DisposeRelation()
        {
            RelatedEdge.Relation = null;
            RelatedCircle.RelationWithEdge = null;
        }

        public void Draw(Graphics g, DrawSettings drawSettings)
        {
            g.DrawString("Tang.",
                drawSettings.TextFont,
                new SolidBrush(drawSettings.LineColor),
                new Point(RelatedCircle.Mid.X, RelatedCircle.Mid.Y + RelatedCircle.R));
            g.DrawString("Tang.",
                drawSettings.TextFont,
                new SolidBrush(drawSettings.LineColor),
                GeometryOperations.EdgeMiddle(RelatedEdge));
        }

        public bool IsRelation()
        {
            return RelatedCircle.R ==
                GeometryOperations.Distance(RelatedEdge,
                    new Point(RelatedCircle.Mid.X, RelatedCircle.Mid.Y));
        }

        public bool RecursivelyRepareRelation(List<ISelectable> Z, Stack<IRelation> S, Func<List<ISelectable>, Stack<IRelation>, bool> recursiveFunction)
        {
            if (!Z.Contains(RelatedCircle))
            {
                if (!GeometryOperations.ChangeCircleRadiusToBeTangentialToEdge(RelatedCircle, RelatedEdge))
                    return false;
                Z.Add(RelatedCircle);
                if (recursiveFunction(Z, S)) return true;
                Z.Remove(RelatedCircle);
            }
            if (!Z.Contains(RelatedCircle.Mid))
            {
                if (!GeometryOperations.ChangeCircleRadiusToBeTangentialToEdge(RelatedCircle, RelatedEdge))
                    return false;
                Z.Add(RelatedCircle.Mid);
                if (recursiveFunction(Z, S)) return true;
                Z.Remove(RelatedCircle.Mid);
            }
            if (!Z.Contains(RelatedEdge.Start))
            {
                if (GeometryOperations.MakeEdgeTangentialToCircle(RelatedEdge, RelatedCircle, true))
                    return false;
                Z.Add(RelatedEdge.Start);
                bool isPushed = !RelatedEdge.Start.PrevEdge.IsRelationFullfiled();
                if (isPushed)
                {
                    S.Push(RelatedEdge.Start.PrevEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
                Z.Remove(RelatedEdge.Start);
                if (isPushed)
                {
                    S.Pop();
                }
            }
            if (!Z.Contains(RelatedEdge.End))
            {
                if (!GeometryOperations.MakeEdgeTangentialToCircle(RelatedEdge, RelatedCircle, false))
                    return false;
                Z.Add(RelatedEdge.End);
                bool isPushed = !RelatedEdge.End.NextEdge.IsRelationFullfiled();
                if (isPushed)
                {
                    S.Push(RelatedEdge.End.NextEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
                Z.Remove(RelatedEdge.End);
                if (isPushed)
                {
                    S.Pop();
                }
            }

            return false;
        }
    }
}
