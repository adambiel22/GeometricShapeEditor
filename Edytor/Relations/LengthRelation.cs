using Edytor.OnlyGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace Edytor.Relations
{
    public class LengthRelation : IRelation
    {
        public Edge RelatedEdge;
        public LengthRelation(Edge edge, int len)
        {
            length = len;
            RelatedEdge = edge;
        }
        public bool IsRelation()
        {
            return length == RelatedEdge.Length;
        }
        public bool RecursivelyRepareRelation(
            List<ISelectable> Z,
            Stack<IRelation> S,
            Func<List<ISelectable>, Stack<IRelation>, bool> recursiveFunction)
        {
            //sprawdzenie czy pierwszy wierzchołek znajduje się w Z
            if (!Z.Contains(RelatedEdge.Start))
            //jeśli nie to go popraw, sprawdź, czy naruszona została jakaś relacja dla sąsiednich krawędzi,
            {
                Z.Add(RelatedEdge.Start);
                GeometryOperations.SetEdgeLength(RelatedEdge, length, true);
                if (!RelatedEdge.Start.PrevEdge.IsRelationFullfiled() &&
                    !S.Contains(RelatedEdge.Start.PrevEdge.Relation))
                {
                    
                    S.Push(RelatedEdge.Start.PrevEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
            }
            else
            {
                Z.Add(RelatedEdge.End);
                int realDistance = GeometryOperations.Distance(RelatedEdge.Start, RelatedEdge.End);
                GeometryOperations.SetEdgeLength(RelatedEdge, length, false);
                if (!RelatedEdge.End.NextEdge.IsRelationFullfiled() &&
                    !S.Contains(RelatedEdge.End.NextEdge.Relation))
                {
                    S.Push(RelatedEdge.End.NextEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
            }
            return false;
            
        }

        public void Draw(Graphics g, DrawSettings drawSettings)
        {
            g.DrawString(length.ToString(),
                drawSettings.TextFont,
                new SolidBrush(drawSettings.LineColor),
                GeometryOperations.EdgeMiddle(RelatedEdge));
        }

        public void DrawWu(Graphics g, DrawSettings drawSettings)
        {
            g.DrawString(length.ToString(),
                drawSettings.TextFont,
                new SolidBrush(drawSettings.LineColor),
                GeometryOperations.EdgeMiddle(RelatedEdge));
        }

        public void DisposeRelation()
        {
            RelatedEdge.SetRelation(null);
            RelatedEdge = null;
        }

        private readonly int length;
    }
}
