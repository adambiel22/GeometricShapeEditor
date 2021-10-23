using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.OnlyGeometry;

namespace Edytor.GeometryVisualization
{
    public class PolygonVisualization : Polygon, IDrawable, ISelectable
    {
        public PolygonVisualization(Point p1, Point p2, Scene scene) : base(p1, p2, scene)
        {
        }

        public bool IsSelected { get; set; }

        public void Delete()
        {
            parentScene.DeleteShape(this);
        }

        public void Draw(Graphics g)
        {
            foreach(PolygonVertex vertex in vertices)
            {
                vertex.
            }
        }

        public void Move(Point p1, Point p2)
        {
            throw new NotImplementedException();
        }

        public ISelectable Select()
        {
            throw new NotImplementedException();
        }
    }
}
