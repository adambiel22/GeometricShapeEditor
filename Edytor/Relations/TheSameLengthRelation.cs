using Edytor.OnlyGeometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.Relations
{
    public class TheSameLengthRelation : IRelation
    {
        public Edge RelatedEdge1;
        public Edge RelatedEdge2;

        public TheSameLengthRelation(Edge e1, Edge e2)
        {
            RelatedEdge1 = e1;
            RelatedEdge2 = e2;
        }

        public void DisposeRelation()
        {
            RelatedEdge1.Relation = null;
            RelatedEdge2.Relation = null;
            RelatedEdge1 = null;
            RelatedEdge2 = null;
        }

        public void Draw(Graphics g, DrawSettings drawSettings)
        {
            g.DrawString(RelatedEdge1.Length.ToString(),
                drawSettings.TextFont,
                new SolidBrush(drawSettings.LineColor),
                GeometryOperations.EdgeMiddle(RelatedEdge1));
            g.DrawString(RelatedEdge1.Length.ToString(),
                drawSettings.TextFont,
                new SolidBrush(Color.Black),
                GeometryOperations.EdgeMiddle(RelatedEdge2));
        }

        public bool IsRelation()
        {
            return Math.Abs(RelatedEdge1.Length - RelatedEdge2.Length) <= 1;
        }

        public bool RecursivelyRepareRelation(List<ISelectable> Z, Stack<IRelation> S, Func<List<ISelectable>, Stack<IRelation>, bool> recursiveFunction)
        {
            if (!Z.Contains(RelatedEdge1.Start))
            {
                Z.Add(RelatedEdge1.Start);
                GeometryOperations.SetEdgeLength(RelatedEdge1, RelatedEdge2.Length, true);
                bool isPushed = !RelatedEdge1.Start.PrevEdge.IsRelationFullfiled();
                if (isPushed)
                {
                    S.Push(RelatedEdge1.Start.PrevEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
                Z.Remove(RelatedEdge1.Start);
                if (isPushed)
                {
                    S.Pop();
                }
            }
            if (!Z.Contains(RelatedEdge2.Start))
            {
                Z.Add(RelatedEdge2.Start);
                GeometryOperations.SetEdgeLength(RelatedEdge2, RelatedEdge1.Length, true);
                bool isPushed = !RelatedEdge2.Start.PrevEdge.IsRelationFullfiled();
                if (isPushed)
                {
                    S.Push(RelatedEdge2.Start.PrevEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
                Z.Remove(RelatedEdge2.Start);
                if (isPushed)
                {
                    S.Pop();
                }
            }
            if (!Z.Contains(RelatedEdge1.End))
            {
                Z.Add(RelatedEdge1.End);
                GeometryOperations.SetEdgeLength(RelatedEdge1, RelatedEdge2.Length, false);
                bool isPushed = !RelatedEdge1.End.NextEdge.IsRelationFullfiled();
                if (isPushed)
                {
                    S.Push(RelatedEdge1.End.NextEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
                Z.Remove(RelatedEdge1.End);
                if (isPushed)
                {
                    S.Pop();
                }
            }
            if (!Z.Contains(RelatedEdge2.End))
            {
                Z.Add(RelatedEdge2.End);
                GeometryOperations.SetEdgeLength(RelatedEdge2, RelatedEdge1.Length, false);
                bool isPushed = !RelatedEdge2.End.NextEdge.IsRelationFullfiled();
                if (isPushed)
                {
                    S.Push(RelatedEdge2.End.NextEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
                Z.Remove(RelatedEdge2.End);
                if (isPushed)
                {
                    S.Pop();
                }
            }
            return false;
        }
    }
}
