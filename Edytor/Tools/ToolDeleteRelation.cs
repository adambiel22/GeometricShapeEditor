using Edytor.OnlyGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edytor.Tools
{
    public class ToolDeleteRelation : Tool
    {
        public ToolDeleteRelation(Scene s, PictureBox pb) : base(s, pb)
        {
        }

        public override void Activate()
        {
            pictureBox.MouseDown += OnMouseDown;
        }

        public override void Disactivate()
        {
            pictureBox.MouseDown -= OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            IRelatable relatable = scene.SelectShape(e.Location) as IRelatable;
            if (relatable != null)
            {
                relatable.SetRelation(null);
                pictureBox.Invalidate();
            }
        }
    }
}
