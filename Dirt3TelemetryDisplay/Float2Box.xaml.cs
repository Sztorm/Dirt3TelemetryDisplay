﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dirt3TelemetryDisplay.Controls
{
    /// <summary>
    /// Interaction logic for Float2Box.xaml
    /// </summary>
    public partial class Float2Box : UserControl
    {
        public bool IsReadOnly { get; set; }

        public float XComponent { get; set; }

        public float YComponent { get; set; }

        public Float2Box()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
