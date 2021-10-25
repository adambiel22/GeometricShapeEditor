using Edytor.OnlyGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edytor.Relations;

namespace Edytor.Tools
{
    public class ToolFixedMidPointRelation : Tool
    {
        public ToolFixedMidPointRelation(Scene s, PictureBox pb) : base(s, pb)
        {
        }

        public override void Activate()
        {
            pictureBox.MouseDown += OnMouseDown;
        }

        public override void Disactivate()
        {
            pictureBox.MouseDown -= OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Circle circle = scene.SelectShape(e.Location) as Circle;
            if (circle != null && circle.ReflexiveRelation == null)
            {
                circle.SetRelation(new FixedMidPointRelation(circle), false);
                pictureBox.Invalidate();
            }
        }
    }
}
