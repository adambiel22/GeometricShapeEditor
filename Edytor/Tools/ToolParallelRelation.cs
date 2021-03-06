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
    public class ToolParallelRelation : Tool
    {
        public ToolParallelRelation(Scene s, PictureBox pb) : base(s, pb)
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
            if (edge != null && edge.Relation == null)
            {
                if (firstSelectedEdge == null)
                {
                    firstSelectedEdge = edge;
                }
                else
                {
                    relation = new ParallelRelation(firstSelectedEdge, edge);
                    firstSelectedEdge.SetRelation(relation, false);
                    edge.SetRelation(relation, true);
                    firstSelectedEdge = null;
                    pictureBox.Invalidate();
                }

            }
        }

        private ParallelRelation relation;
        private Edge firstSelectedEdge;

    }
}
