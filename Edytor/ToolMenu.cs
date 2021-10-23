using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edytor.Geometry;
using Edytor.Tools;

namespace Edytor
{
    public class ToolMenu
    {
        private Scene scene;
        private PictureBox pictureBox;

        private Button polygonButton;
        private Button circleButton;
        private Button selectButton;

        private ToolCircle toolCircle;
        private ToolPolygon toolPolygon;
        private ToolSelect toolSelect;

        private Tool activeTool;

        public ToolMenu(PictureBox pb, Button polygon, Button circle, Button select)
        {
            pictureBox = pb;
            scene = new Scene();
            toolCircle = new ToolCircle(scene, pictureBox);
            toolPolygon = new ToolPolygon(scene, pictureBox);
            toolSelect = new ToolSelect(scene, pictureBox);
            polygonButton = polygon;
            circleButton = circle;
            selectButton = select;
            activeTool = null;

            polygonButton.Click += polygonButton_Click;
            circleButton.Click += circleButton_Click;
            selectButton.Click += selectButton_Click;
            selectButton.KeyDown += toolSelect.OnKeyDown;
            pictureBox.Paint += pictureBox_Paint;

        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            scene.DrawShape(g);
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            activateTool(toolPolygon);
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            activateTool(toolCircle);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            activateTool(toolSelect);
        }

        private void activateTool(Tool tool)
        {
            if (activeTool != null)
            {
                pictureBox.MouseDown -= activeTool.OnMouseDown;
                pictureBox.MouseMove -= activeTool.OnMouseMove;
                pictureBox.MouseDown -= activeTool.OnMouseUp;
            }
            activeTool = tool;
            pictureBox.MouseDown += tool.OnMouseDown;
            pictureBox.MouseMove += tool.OnMouseMove;
            pictureBox.MouseUp += tool.OnMouseUp;
        }
    }
}
