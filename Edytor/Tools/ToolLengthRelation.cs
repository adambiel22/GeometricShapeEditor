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
    public class ToolLengthRelation : Tool
    {
        public ToolLengthRelation(Scene s, PictureBox pb) : base(s, pb)
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
                LengthDialog dialog = new LengthDialog(edge.Length);
                dialog.ShowDialog(pictureBox);
                if (dialog.DialogResult == DialogResult.OK)
                {
                    relation = new LengthRelation(edge, dialog.Value);
                    edge.SetRelation(relation);
                    pictureBox.Invalidate();
                }
                
            }
        }

        private LengthRelation relation;
    }
}
