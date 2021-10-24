using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class Scene : IDrawable
    {
        public Scene()
        {
            shapes = new HashSet<IShape>();
        }
        public void DeleteShape(IShape shape)
        {
            shapes.Remove(shape);
        }

        public void AddShape(IShape shape)
        {
            shapes.Add(shape);
        }

        public void Draw(Graphics g)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }
        }

        public ISelectable SelectShape(Point point)
        {
            foreach (var shape in shapes)
            {
                ISelectable selectable = shape.Select(point);
                if (selectable != null)
                    return selectable;
            }
            return null;
        }

        private HashSet<IShape> shapes;
    }
}
