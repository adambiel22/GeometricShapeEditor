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
    public class ToolTangentialRelation : Tool
    {
        public ToolTangentialRelation(Scene s, PictureBox pb) : base(s, pb)
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
            ISelectable selectable = scene.SelectShape(e.Location);
            Edge edge = selectable as Edge;
            Circle circle = selectable as Circle;
            if (edge != null && edge.Relation == null)
            {
                if (firstSelectedEdge == null && firstSelectedCircle == null)
                {
                    firstSelectedEdge = edge;
                }
                else if (firstSelectedCircle != null)
                {
                    IRelation relation = new TangentialRelation(edge, firstSelectedCircle);
                    firstSelectedCircle.SetRelation(relation, false);
                    edge.SetRelation(relation, true);
                    firstSelectedCircle = null;
                    pictureBox.Invalidate();
                }
            }
            else if (circle != null && circle.RelationWithEdge == null)
            {
                if (firstSelectedEdge == null && firstSelectedCircle == null)
                {
                    firstSelectedCircle = circle;
                }
                else if (firstSelectedEdge != null)
                {
                    IRelation relation = new TangentialRelation(firstSelectedEdge, circle);
                    circle.SetRelation(relation, false);
                    firstSelectedEdge.SetRelation(relation, true);
                    firstSelectedEdge = null;
                    pictureBox.Invalidate();
                }
            }
        }

        private Edge firstSelectedEdge;
        private Circle firstSelectedCircle;
    }
}
