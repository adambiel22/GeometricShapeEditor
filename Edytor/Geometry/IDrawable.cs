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

namespace Edytor.Geometry
{
    public interface IDrawable
    {
        public enum HitState{
            Nothing,
            Vertex,
            Edge,
            CircleBorder,
            Circle,
            Polygon
        } 

        public void DrawShape(Graphics g);
        public void Move(Point start, Point end);

        public IDrawable Hit(Point point);

        public void Delete();
    }
}
