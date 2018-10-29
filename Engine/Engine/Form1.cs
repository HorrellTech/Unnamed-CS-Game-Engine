using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            glGameCanvas1.OnDraw += GlGameCanvas1_OnDraw;
        }
        int x = 0;
        private void GlGameCanvas1_OnDraw(object sender, PaintEventArgs e)
        {
            x++;
            e.Graphics.FillRectangle(Brushes.Red, x, 0, 64, 64);
        }
    }
}
