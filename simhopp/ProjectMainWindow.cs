﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public partial class ProjectMainWindow : Form
    {
        #region Properties
        private PanelViewControl CurrentPanel { get; set; }

        public ProjectMainWindow()
        {
            InitializeComponent();
        }
    }
}
