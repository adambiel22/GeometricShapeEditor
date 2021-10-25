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
using Edytor.Relations;

namespace Edytor
{
    public class ToolMenu
    {
        private Scene scene;
        private PictureBox pictureBox;

        private ListView drawListView;
        private SceneSettings sceneSettings;

        private Tool activeTool;

        public ToolMenu(PictureBox pb, ListView draw)
        {
            pictureBox = pb;
            scene = predefinedScene();
            drawListView = draw;
            sceneSettings = new SceneSettings();

            ListViewItem item;
            item = new ListViewItem("Polygon");
            item.Tag = new ToolPolygon(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Circle");
            item.Tag = new ToolCircle(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Select");
            item.Tag = new ToolSelect(scene, pictureBox, drawListView);
            drawListView.Items.Add(item);

            item = new ListViewItem("Split Edge");
            item.Tag = new ToolSplitEdge(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Length Relation");
            item.Tag = new ToolLengthRelation(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("The Same Length Relation");
            item.Tag = new ToolTheSameLengthRelation(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Parallel Relation");
            item.Tag = new ToolParallelRelation(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Tangential Relation");
            item.Tag = new ToolTangentialRelation(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Fixed Mid Point Relation");
            item.Tag = new ToolFixedMidPointRelation(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Fixed Radius Relation");
            item.Tag = new ToolFixedRadiusRelation(scene, pictureBox);
            drawListView.Items.Add(item);

            item = new ListViewItem("Delete Relation");
            item.Tag = new ToolDeleteRelation(scene, pictureBox);
            drawListView.Items.Add(item);

            activeTool = null;

            pictureBox.Paint += pictureBox_Paint;
            drawListView.SelectedIndexChanged += DrawListView_SelectedIndexChanged;
        }

        private void DrawListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeTool != null) activeTool.Disactivate();
            if (drawListView.SelectedItems.Count != 0)
            {
                activeTool = drawListView.SelectedItems[0].Tag as Tool;
                if (activeTool != null) activeTool.Activate();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            scene.Draw(g, sceneSettings.DrawSettings);
        }

        private Scene predefinedScene()
        {
            Scene scene = new Scene();
            Polygon polygon1 = new Polygon(new Point(200, 200), new Point(400, 215), scene);
            Polygon polygon2 = new Polygon(new Point(800, 200), new Point(800, 400), scene);
            Circle circle1 = new Circle(new Point(200, 400), 40, scene);
            Circle circle2 = new Circle(new Point(400, 400), 80, scene);
            scene.AddShape(polygon1);
            scene.AddShape(polygon2);
            scene.AddShape(circle1);
            scene.AddShape(circle2);
            polygon1.AddVertex(new Point(600, 350));
            polygon1.AddVertex(new Point(500, 400));

            polygon2.AddVertex(new Point(720, 500));
            polygon2.AddVertex(new Point(700, 50));

            polygon1.edges[0].SetRelation(new LengthRelation(polygon1.edges[0], 300), true);

            IRelation relation = new ParallelRelation(polygon1.edges[1], polygon1.edges[3]);
            polygon1.edges[1].SetRelation(relation, false);
            polygon1.edges[3].SetRelation(relation, true);

            relation = new TheSameLengthRelation(polygon2.edges[1], polygon2.edges[3]);
            polygon2.edges[1].SetRelation(relation, false);
            polygon2.edges[3].SetRelation(relation, true);

            circle1.SetRelation(new FixedMidPointRelation(circle1), true);
            circle2.SetRelation(new FixedRadiusRelation(circle2), true);

            return scene;
        }
    }
}
