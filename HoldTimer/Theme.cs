using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;

namespace HoldTimer
{
    public class Theme
    {
        public string Name { get; set; } = "Default";
        public string Description { get; set; } = "The standard default theme built into HoldTimer";

        public Color AppBackColor { get; set; } = Color.FromArgb(51, 31, 67);
        public Color TimerBackColor { get; set; } = Color.FromArgb(80, 60, 100);
        public Color TimerForeColor { get; set; } = Color.Gray;
        public Color TimeDefaultColor { get; set; } = Color.FromArgb(63, 150, 131);
        public Color AlertTimeColor { get; set; } = Color.Yellow;
        public Color OverTimeColor { get; set; } = Color.Red;

        public Theme()
        {

        }
    }
}
