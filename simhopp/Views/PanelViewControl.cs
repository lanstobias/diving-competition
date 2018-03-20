using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    /// <summary>
    /// This is the parent that all the View inherit. So change something on this, and it will affect every view
    /// </summary>
    public partial class PanelViewControl : UserControl
    {
        public PanelViewControl()
        {
            InitializeComponent();
        }

    }
}
