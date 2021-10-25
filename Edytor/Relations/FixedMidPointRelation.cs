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
    public class FixedMidPointRelation : IRelation
    {
        public Circle RelatedCircle { get; set; }
        public FixedMidPointRelation(Circle circle)
        {
            RelatedCircle = circle;
            fixedPoint = new Point(circle.Mid.X, circle.Mid.Y);
        }
        public void DisposeRelation()
        {
            RelatedCircle.SetRelation(null);
        }

        public void Draw(Graphics g, DrawSettings drawSettings)
        {
            g.DrawString("Fixed",
                drawSettings.TextFont,
                new SolidBrush(drawSettings.LineColor),
                new Point(RelatedCircle.Mid.X, RelatedCircle.Mid.Y));
        }

        public void DrawWu(Graphics g, DrawSettings drawSettings)
        {
            g.DrawString("Fixed",
                drawSettings.TextFont,
                new SolidBrush(drawSettings.LineColor),
                new Point(RelatedCircle.Mid.X, RelatedCircle.Mid.Y));
        }

        public bool IsRelation()
        {
            return fixedPoint.X == RelatedCircle.Mid.X && fixedPoint.Y == RelatedCircle.Mid.Y;
        }

        public bool RecursivelyRepareRelation(List<ISelectable> Z, Stack<IRelation> S, Func<List<ISelectable>, Stack<IRelation>, bool> recursiveFunction)
        {
            return false;
        }

        private Point fixedPoint; 
    }
}
