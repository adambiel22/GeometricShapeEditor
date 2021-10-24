using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class Circle : IShape
    {
        public MidPoint Mid { get; set; }
        public int R { get; set; }
        public Scene ParentScene { get; set; }
        public bool IsSelected { get; set; }

        public Circle(Point mid, int r, Scene parentScene)
        {
            Mid = new MidPoint(mid, this);
            R = r;
            ParentScene = parentScene;
        }

        public void Draw(Graphics g)
        {
            Mid.Draw(g);
            g.DrawEllipse(new Pen(Color.Black), new Rectangle(Mid.X - R, Mid.Y - R, 2 * R, 2 * R));
        }

        public ISelectable Select(Point point)
        {
            int r = GeometryOperations.Distance(point, new Point(Mid.X, Mid.Y));
            if (R - 4 <= r && r <= R + 4)
            {
                return this;
            }
            else if (r < R)
            {
                return Mid;
            }
            return null;
        }

        public void Delete()
        {
            ParentScene.DeleteShape(this);
        }

        public void Move(Point p1, Point p2)
        {
            R = (int)Math.Sqrt((Mid.X - p2.X) * (Mid.X - p2.X) + (Mid.Y - p2.Y) * (Mid.Y - p2.Y));
        }
    }
}
