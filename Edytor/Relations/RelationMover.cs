using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.OnlyGeometry;
using System.Drawing;


namespace Edytor.Relations
{
    public class RelationMover
    { 
        public static bool MoveSetOfPolygonVericies(List<PolygonVertex> polygonVertices,
            Point p1, Point p2)
        {
            Stack<IRelation> S = new Stack<IRelation>();
            foreach (PolygonVertex polygonVertex in polygonVertices)
            {
                GeometryOperations.AddVectorToVertex(polygonVertex, p1, p2);
                if (!polygonVertex.NextEdge.IsRelationFullfiled() && !S.Contains(polygonVertex.NextEdge.Relation))
                    S.Push(polygonVertex.NextEdge.Relation);
                if (!polygonVertex.PrevEdge.IsRelationFullfiled() && !S.Contains(polygonVertex.PrevEdge.Relation))
                    S.Push(polygonVertex.PrevEdge.Relation);
            }
            return Recursion(new List<ISelectable>(polygonVertices), S);
        }

        public static bool Recursion(List<ISelectable> Z, Stack<IRelation> S)
        {
            if (S.Count == 0) return true;
            IRelation relation = S.Pop();
            if (relation.IsRelation())
                return Recursion(Z, S);
            if(!relation.RecursivelyRepareRelation(Z, S, Recursion))
            {
                S.Push(relation);
                return false;
            }
            return true;
        }
    }
}
