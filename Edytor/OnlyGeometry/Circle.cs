using Edytor.Relations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class Circle : IShape, IRelatable
    {
        public MidPoint Mid { get; set; }
        public int R { get; set; }
        public Scene ParentScene { get; set; }
        public bool IsSelected { get; set; }
        public IRelation ReflexiveRelation { get; set; }
        public IRelation RelationWithEdge { get; set; }

        public Circle(Point mid, int r, Scene parentScene)
        {
            Mid = new MidPoint(mid, this);
            R = r;
            ParentScene = parentScene;
        }

        public void Draw(Graphics g, DrawSettings drawSettings)
        {
            Mid.Draw(g, drawSettings);
            g.DrawEllipse(
                new Pen(IsSelected ? drawSettings.SelectionColor : drawSettings.LineColor), 
                new Rectangle(Mid.X - R, Mid.Y - R, 2 * R, 2 * R));
            if (ReflexiveRelation != null)
            {
                ReflexiveRelation.Draw(g, drawSettings);
            }
        }

        public ISelectable Select(Point point)
        {
            if (GeometryOperations.Distance(point, new Point(Mid.X, Mid.Y)) < R + 4)
            {
                return this;
            }
            return null;
        }

        public void Delete()
        {
            ParentScene.DeleteShape(this);
        }

        public bool Move(Point p1, Point p2)
        {
            int r = GeometryOperations.Distance(p1, new Point(Mid.X, Mid.Y));
            bool i = true;
            if (R - 4 <= r && r <= R + 4)
            {
                if ((ReflexiveRelation as FixedRadiusRelation) != null)
                    return false;
                R = (int)Math.Sqrt((
                    Mid.X - p2.X) * (Mid.X - p2.X) +
                    (Mid.Y - p2.Y) * (Mid.Y - p2.Y));
                i = true;
            }
            else if (r < R)
            {
                if ((ReflexiveRelation as FixedMidPointRelation) != null)
                    return false;
                GeometryOperations.AddVectorToVertex(Mid, p1, p2);
                i = false;
            }
            if (RelationWithEdge != null && !RelationWithEdge.IsRelation())
            {
                Stack<IRelation> S = new Stack<IRelation>();
                S.Push(RelationWithEdge);
                return RelationMover.Recursion(
                    new List<ISelectable> { i ? this : Mid }, S);
            }
            return true;
        }

        public void SetRelation(IRelation relation, bool ifRepare = true)
        {
            ReflexiveRelation = relation;
        }

        public bool IsRelationFullfiled()
        {
            return ReflexiveRelation == null || ReflexiveRelation.IsRelation();
        }
    }
}
