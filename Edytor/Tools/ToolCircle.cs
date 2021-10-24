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
        public ToolCircle(Scene s, PictureBox pb) : base(s, pb) { }

        public override void Activate()
        {
            pictureBox.MouseDown += OnMouseDown;
            pictureBox.MouseMove += OnMouseMove;
        }

        public override void Disactivate()
        {
            pictureBox.MouseDown -= OnMouseDown;
            pictureBox.MouseMove -= OnMouseMove;
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                if (State == ToolState.Idle)
                {
                    State = ToolState.InAction;
                    circle = new Circle(e.Location, 1, scene);
                    scene.AddShape(circle);
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
                circle.R = (int)Math.Sqrt((e.X - circle.Mid.X) * (e.X - circle.Mid.X) + (e.Y - circle.Mid.Y) * (e.Y - circle.Mid.Y));
                pictureBox.Invalidate();
            }
        }

        private Circle circle;
    }
}
