using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edytor
{
    public partial class LengthDialog : Form
    {
        public LengthDialog(int initialValue)
        {
            InitializeComponent();
            numericUpDown.Value = initialValue;
        }
        public int Value
        {
            get 
            {
                return (int)numericUpDown.Value;   
            }
        }
    }
}
