using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.OnlyGeometry;
using System.Drawing;


namespace Edytor.Relations
{
    public class RelaetionMover
    { 
        public bool MoveSetOfPolygonVericies(List<PolygonVertex> polygonVertices, Point p1, Point p2) //zbiór wierzchołków oraz typ przesunięcia
        {
            Stack<IRelation> S = new Stack<IRelation>();
            foreach (PolygonVertex polygonVertex in polygonVertices)
            {
                polygonVertex.Move(p1, p2);
                if (!polygonVertex.NextEdge.Relation.IsRelation() && !S.Contains(polygonVertex.NextEdge.Relation))
                    S.Push(polygonVertex.NextEdge.Relation);
                if (!polygonVertex.PrevEdge.Relation.IsRelation() && !S.Contains(polygonVertex.PrevEdge.Relation))
                    S.Push(polygonVertex.PrevEdge.Relation);
            }
            return Recursion(polygonVertices, S);
        }

        public bool Recursion(List<PolygonVertex> Z, Stack<IRelation> S)
        {
            if (S.Count == 0) return true;
            IRelation relation = S.Pop();
            if (relation.IsRelation())
                return Recursion(Z, S);
            return relation.RecursivelyRepareRelation(Z, S, Recursion);
        }
    }
}
