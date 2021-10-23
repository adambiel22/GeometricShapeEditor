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

namespace Edytor.Tools
{
    public abstract class Tool
    {
        protected readonly Scene scene;
        protected readonly PictureBox pictureBox;
        public enum ToolState
        {
            InAction,
            Idle
        }

        public Tool(Scene s, PictureBox pb)
        {
            scene = s;
            pictureBox = pb;
            State = ToolState.Idle;
        }

        public virtual void OnMouseDown(object sender, MouseEventArgs e) { }
        public virtual void OnMouseMove(object sender, MouseEventArgs e) { }
        public virtual void OnMouseUp(object sender, MouseEventArgs e) { }

        public ToolState State { get; protected set; }
    }
}
