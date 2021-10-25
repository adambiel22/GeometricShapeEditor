using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Edytor.OnlyGeometry
{
    public class SceneSettings
    {
        public DrawSettings DrawSettings { get; set; }

        public SceneSettings()
        {
            DrawSettings = new DrawSettings();
        }
    }
}
