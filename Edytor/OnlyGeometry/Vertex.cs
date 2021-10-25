using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.Relations;

namespace Edytor.OnlyGeometry
{
    public abstract class Vertex : IDrawable, ISelectable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsSelected { get; set; }

        public Vertex(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual bool Move(Point start, Point end)
        {
            X += end.X - start.X;
            Y += end.Y - start.Y;
            return true;
        }

        public void Draw(Graphics g, DrawSettings drawSettings)
        {
            g.FillEllipse(
                new SolidBrush(
                    IsSelected ? drawSettings.SelectionColor : drawSettings.VertexColor ),
                new Rectangle(X - drawSettings.VertexRadius, Y - drawSettings.VertexRadius,
                2*drawSettings.VertexRadius, 2 * drawSettings.VertexRadius));
        }

        public ISelectable Select(Point point)
        {
            if ((point.X - X) * (point.X - X) + (point.Y - Y) * (point.Y - Y) <= 25) //sparametryzować to!
            {
                return this;
            }
            return null;
        }
        public abstract void Delete();
    }
}
