using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.OnlyGeometry;

namespace Edytor.GeometryVisualization
{
    public class PolygonVertexVisualization : PolygonVertex, IDrawable, ISelectable
    {
        public bool IsSelected { get; set; }

        public PolygonVertexVisualization(Point p, Polygon polygon) : base(p, polygon)
        {
        }

        public PolygonVertexVisualization(int x, int y, Polygon polygon) : base(x, y, polygon)
        {
        }
        
        public void Delete()
        {
            IsSelected = false;
            ParentPolygon.DeleteVertex(this);
        }

        //do poprawy, sparametryzowanie
        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(X - 2, Y - 2, 4, 4));
        }

        public ISelectable Select()
        {
            throw new NotImplementedException();
        }
    }
}
