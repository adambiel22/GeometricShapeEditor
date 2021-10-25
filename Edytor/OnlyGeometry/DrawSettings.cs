using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace Edytor.OnlyGeometry
{
    public class DrawSettings
    {
        public Color SelectionColor { get; set; }
        public Color LineColor { get; set; }
        public Color VertexColor { get; set; }
        public int VertexRadius { get; set; }
        public Font TextFont { get; set; }
        public DrawSettings()
        {
            SelectionColor = Color.Blue;
            LineColor = Color.Black;
            VertexColor = Color.Gray;
            VertexRadius = 5;
            TextFont = new Font(new FontFamily(GenericFontFamilies.Monospace), 10);
        }
    }
}
