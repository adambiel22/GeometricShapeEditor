using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Edytor.OnlyGeometry
{
    public interface IDrawable
    {
        public void Draw(Graphics g, DrawSettings drawSettings);

        public void DrawWu(Graphics g, DrawSettings drawSettings);
    }
}
