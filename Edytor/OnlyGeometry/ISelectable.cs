using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//usunąć niepotrzebne usingi

namespace Edytor.OnlyGeometry
{
    public interface ISelectable
    {
        public bool IsSelected { get; set; }
        public ISelectable Select(Point point);
        public void Delete();
        public void Move(Point p1, Point p2);
    }
}
