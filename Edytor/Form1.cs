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
using Edytor.Tools;

namespace Edytor
{
    public partial class Form1 : Form
    {
        private ToolMenu toolMenu;

        public Form1()
        {
            InitializeComponent();
            toolMenu = new ToolMenu(pictureBox, selectButton, drawListView);
        }
    }
}
