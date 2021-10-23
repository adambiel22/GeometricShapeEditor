using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edytor.OnlyGeometry;

namespace Edytor.Tools
{
    public class ToolCircle : Tool
    {
        private Circle circle;
        public ToolCircle(Scene s, PictureBox pb) : base(s, pb) { }

        public override void Activate()
        {
            throw new NotImplementedException();
        }

        public override void Disactivate()
        {
            throw new NotImplementedException();
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                if (State == ToolState.Idle)
                {
                    State = ToolState.InAction;
                    //circle = new Circle(e.Location, 1);
                    //scene.AddShape(circle);
                }
                else
                {
                    State = ToolState.Idle;
                }
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (State == ToolState.InAction)
            {
                circle.R = (int)Math.Sqrt((e.X - circle.MidPoint.X) * (e.X - circle.MidPoint.X) + (e.Y - circle.MidPoint.Y) * (e.Y - circle.MidPoint.Y));
                pictureBox.Invalidate();
            }
        }
    }
}
