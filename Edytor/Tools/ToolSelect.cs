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

        public ToolSelect(Scene s, PictureBox pb, Control controlArg) : base(s, pb)
        {
            control = controlArg;
        }

        public override void Activate()
        {
            pictureBox.MouseDown += OnMouseDown;
            control.KeyDown += DeleteKeyDown;
        }

        public override void Disactivate()
        {
            if (selectedShape != null)
            {
                selectedShape.IsSelected = false;
                selectedShape = null;
                pictureBox.Invalidate();
            }
            pictureBox.MouseDown -= OnMouseDown;
            control.KeyDown -= DeleteKeyDown;
        }

        private void DeleteKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (selectedShape != null)
                {
                    selectedShape.Delete();
                    selectedShape = null;
                    pictureBox.Invalidate();
                }
            }
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ISelectable selectable = scene.SelectShape(e.Location);
                if (selectable != null)
                {
                    if (selectedShape != null) selectedShape.IsSelected = false;
                    selectedShape = selectable;
                    selectedShape.IsSelected = true;
                    previousPoint = e.Location;
                    pictureBox.MouseMove += OnMouseMove;
                    pictureBox.MouseUp += OnMouseUp;
                }
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!selectedShape.Move(previousPoint, e.Location))
            {
                pictureBox.MouseMove -= OnMouseMove;
                pictureBox.MouseUp -= OnMouseUp;
                MessageBox.Show("Couldn't do this operation");
            }
            previousPoint = e.Location;
            pictureBox.Invalidate();
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            pictureBox.MouseMove -= OnMouseMove;
            pictureBox.MouseUp -= OnMouseUp;
        }
        private ISelectable selectedShape;
        private Point previousPoint;
        private Control control;
    }
}
