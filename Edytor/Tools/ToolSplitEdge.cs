using Edytor.OnlyGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edytor.Tools
{
    class ToolSplitEdge : Tool
    {
        public ToolSplitEdge(Scene s, PictureBox pb) : base(s, pb)
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
            Edge edge = scene.SelectShape(e.Location) as Edge;
            if (edge != null)
            {
                edge.ParentPolygon.SplitEdge(edge);
                pictureBox.Invalidate();
            }
        }
    }
}
