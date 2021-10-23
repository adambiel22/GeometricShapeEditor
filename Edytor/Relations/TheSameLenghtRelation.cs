using Edytor.OnlyGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.Relations
{
    public class TheSameLenghtRelation : IRelation
    {
        public Edge RelatedEdge1; //public czy private??
        public Edge RelatedEdge2;

        public TheSameLenghtRelation(Edge e1, Edge e2)
        {
            RelatedEdge1 = e1;
            RelatedEdge1 = e2;
        }
        public bool IsRelation()
        {
            return RelatedEdge1.Lenght == RelatedEdge2.Lenght;
        }

        public bool RecursivelyRepareRelation(List<PolygonVertex> Z, Stack<IRelation> S, Func<List<PolygonVertex>, Stack<IRelation>, bool> recursiveFunction)
        {
            if (!Z.Contains(RelatedEdge1.Start))
            {
                Z.Add(RelatedEdge1.Start);
                GeometryOperations.SetEdgeLenght(RelatedEdge1, RelatedEdge2.Lenght, true);
                bool isPushed = !RelatedEdge1.Start.PrevEdge.Relation.IsRelation();
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
                GeometryOperations.SetEdgeLenght(RelatedEdge2, RelatedEdge1.Lenght, true);
                bool isPushed = !RelatedEdge2.Start.PrevEdge.Relation.IsRelation();
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
                GeometryOperations.SetEdgeLenght(RelatedEdge1, RelatedEdge2.Lenght, false);
                bool isPushed = !RelatedEdge1.End.NextEdge.Relation.IsRelation();
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
                GeometryOperations.SetEdgeLenght(RelatedEdge2, RelatedEdge1.Lenght, false);
                bool isPushed = !RelatedEdge2.End.NextEdge.Relation.IsRelation();
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
