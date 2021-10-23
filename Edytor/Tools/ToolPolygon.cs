using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edytor.Geometry;

namespace Edytor.Tools
{
    public class ToolPolygon : Tool
    {
        private Polygon polygon;

        public ToolPolygon(Scene s, PictureBox pb) : base(s, pb) { }

        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                if (State == ToolState.Idle)
                {
                    State = ToolState.InAction;
                    polygon = new Polygon(new Edge(e.Location, e.Location));
                    scene.AddShape(polygon);
                }
                else
                {
                    polygon.AddVertex(new Vertex(e.Location));
                }
            }
            else if (MouseButtons.Right == e.Button)
            {
                if (State == ToolState.InAction)
                {
                    State = ToolState.Idle;
                }
            }
        }

        public override void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (State == ToolState.InAction)
            {
                polygon.MoveVertex(polygon.VerticesCount - 1, e.Location);
                pictureBox.Invalidate();
            }
        }
    }
}
