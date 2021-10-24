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
            List<PolygonVertex> Z,
            Stack<IRelation> S,
            Func<List<PolygonVertex>, Stack<IRelation>, bool> recursiveFunction)
        {
            //sprawdzenie czy pierwszy wierzchołek znajduje się w Z
            if (!Z.Contains(RelatedEdge.Start))
            //jeśli nie to go popraw, sprawdź, czy naruszona została jakaś relacja dla sąsiednich krawędzi,
            {
                Z.Add(RelatedEdge.Start);
                GeometryOperations.SetEdgeLength(RelatedEdge, length, true);
                if (!RelatedEdge.Start.PrevEdge.IsRelationFullfiled())
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
                if (!RelatedEdge.End.NextEdge.IsRelationFullfiled())
                {
                    S.Push(RelatedEdge.End.NextEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
            }
            return false;
            
        }

        public void Draw(Graphics g)
        {
            g.DrawString(length.ToString(),
                new Font(new FontFamily(GenericFontFamilies.Monospace), 12),
                new SolidBrush(Color.Black),
                GeometryOperations.EdgeMiddle(RelatedEdge));
        }

        private readonly int length;
    }
}
