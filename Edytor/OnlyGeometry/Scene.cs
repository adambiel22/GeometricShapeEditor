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
            polygons = new HashSet<Polygon>();
        }
        public void DeleteShape(Polygon polygon)
        {
            polygons.Remove(polygon);
        }

        public void AddShape(Polygon polygon)
        {
            polygons.Add(polygon);
        }

        public void Draw(Graphics g)
        {
            foreach (var shape in polygons)
            {
                shape.Draw(g);
            }
        }

        public ISelectable SelectShape(Point point)
        {
            foreach (var shape in polygons)
            {
                ISelectable selectable = shape.Select(point);
                if (selectable != null)
                    return selectable;
            }
            return null;
        }

        private HashSet<Polygon> polygons;
    }
}
