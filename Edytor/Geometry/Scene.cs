using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.Geometry
{
    public class Scene : IDrawable
    {
        public List<IDrawable> Shapes { get; }

        public Scene()
        {
            Shapes = new List<IDrawable>();
        }
        public void DrawShape(Graphics g)
        {
            foreach(var shape in Shapes)
            {
                shape.DrawShape(g);
            }
        }

        public void AddShape(IDrawable drawable)
        {
            Shapes.Add(drawable);
        }

        public void Move(Point start, Point end)
        {
            return;
        }

        public IDrawable Hit(Point point)
        {
            foreach (var shape in Shapes)
            {
                IDrawable drawable = shape.Hit(point);
                if (drawable != null)
                {
                    return drawable;
                }
            }
            return null;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
