using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edytor.OnlyGeometry;

namespace Edytor.Tools
{
    public abstract class Tool
    {
        protected enum ToolState {
            Idle,
            InAction
        }

        protected readonly Scene scene;
        protected readonly PictureBox pictureBox;
        protected ToolState State;

        public Tool(Scene s, PictureBox pb)
        {
            scene = s;
            pictureBox = pb;
            State = ToolState.Idle;
        }

        public abstract void Activate();

        public abstract void Disactivate();
    }
}
