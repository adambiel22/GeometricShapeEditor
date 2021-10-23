using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.OnlyGeometry;

namespace Edytor.GeometryVisualization
{
    public class CircleVisualizaion : Circle, IDrawable, ISelectable
    {
        bool ISelectable.IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public void Move(Point p1, Point p2)
        {
            throw new NotImplementedException();
        }

        public ISelectable Select()
        {
            throw new NotImplementedException();
        }

        void ISelectable.Delete()
        {
            throw new NotImplementedException();
        }

        void ISelectable.Move(Point p1, Point p2)
        {
            throw new NotImplementedException();
        }

        ISelectable ISelectable.Select()
        {
            throw new NotImplementedException();
        }
    }
}
