using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Edytor.GeometryVisualization
{
    public interface IDrawable
    {
        public void Draw(Graphics g);
    }
}
