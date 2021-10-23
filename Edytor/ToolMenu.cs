using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edytor.OnlyGeometry;
using Edytor.Tools;

namespace Edytor
{
    public class ToolMenu
    {
        private Scene scene;
        private PictureBox pictureBox;

        private Button selectButton;
        private ListView drawListView;

        private Tool activeTool;

        public ToolMenu(PictureBox pb, Button select, ListView draw)
        {
            pictureBox = pb;
            scene = new Scene();
            drawListView = draw;

            ListViewItem item;
            item = new ListViewItem("Polygon");
            item.Tag = new ToolPolygon(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Circle");
            item.Tag = new ToolCircle(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Select");
            item.Tag = new ToolSelect(scene, pictureBox);
            drawListView.Items.Add(item);

            selectButton = select;
            activeTool = null;


            pictureBox.Paint += pictureBox_Paint;
            drawListView.SelectedIndexChanged += DrawListView_SelectedIndexChanged;
        }

        private void DrawListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeTool != null) activeTool.Disactivate();
            activeTool = drawListView.SelectedItems[0].Tag as Tool;
            if (activeTool != null) activeTool.Activate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            scene.Draw(g);
        }
    }
}
