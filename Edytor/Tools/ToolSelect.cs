using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Edytor.OnlyGeometry;

namespace Edytor.Tools
{
    public class ToolSelect : Tool
    {
        private IDrawable selectedShape;
        private Point previousPoint;
        public ToolSelect(Scene s, PictureBox pb) : base(s, pb) { }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    //IDrawable drawable = scene.Hit(e.Location);
            //    if (drawable != null)
            //    {
            //        selectedShape = drawable;
            //        previousPoint = e.Location;
            //        State = ToolState.InAction;
            //    }
            //}
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (State == ToolState.InAction)
            {
                //selectedShape.Move(previousPoint, e.Location);
                previousPoint = e.Location;
                pictureBox.Invalidate();
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (State == ToolState.InAction)
            {
                State = ToolState.Idle;
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (selectedShape != null)
            {
                //selectedShape.Delete();
                selectedShape = null;
                pictureBox.Invalidate();
            }
        }

        public override void Activate()
        {
            throw new NotImplementedException();
        }

        public override void Disactivate()
        {
            throw new NotImplementedException();
        }
    }
}
