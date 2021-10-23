using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//usunąć niepotrzebne usingi

namespace Edytor.GeometryVisualization
{
    public interface ISelectable
    {
        public ISelectable Select();
        public void Delete();
        public void Move(Point p1, Point p2);
        public bool IsSelected { get; set; }
    }
}
