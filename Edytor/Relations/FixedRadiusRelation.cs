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
    public class FixedRadiusRelation : IRelation
    {
        public Circle RelatedCircle { get; set; }
        public FixedRadiusRelation(Circle circle)
        {
            RelatedCircle = circle;
            fixedRadius = circle.R;
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
                new Point(RelatedCircle.Mid.X + RelatedCircle.R, RelatedCircle.Mid.Y));
        }

        public bool IsRelation()
        {
            return fixedRadius == RelatedCircle.R;
        }

        public bool RecursivelyRepareRelation(List<ISelectable> Z, Stack<IRelation> S, Func<List<ISelectable>, Stack<IRelation>, bool> recursiveFunction)
        {
            return false;
        }

        private int fixedRadius; 
    }
}
