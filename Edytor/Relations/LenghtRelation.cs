using Edytor.OnlyGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Edytor.Relations
{
    public class LenghtRelation : IRelation
    {
        public Edge RelatedEdge;
        public LenghtRelation(Edge edge, int len)
        {
            lenght = len;
        }
        public bool IsRelation()
        {
            return lenght * lenght == GeometryOperations.DistanceSquare(RelatedEdge.Start, RelatedEdge.End);
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
                GeometryOperations.SetEdgeLenght(RelatedEdge, lenght, true);
                if (!RelatedEdge.Start.PrevEdge.Relation.IsRelation())
                {
                    S.Push(RelatedEdge.Start.PrevEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
            }
            else
            {
                Z.Add(RelatedEdge.End);
                int realDistance = GeometryOperations.Distance(RelatedEdge.Start, RelatedEdge.End);
                GeometryOperations.SetEdgeLenght(RelatedEdge, lenght, false);
                if (!RelatedEdge.End.NextEdge.Relation.IsRelation())
                {
                    S.Push(RelatedEdge.End.NextEdge.Relation);
                }
                if (recursiveFunction(Z, S)) return true;
            }

            return false;
            
        }

        private readonly int lenght;
    }
}
