using Dirt3TelemetryDisplay;
using System;
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
    /// Interaction logic for Float3Box.xaml
    /// </summary>
    public partial class Float3Box : UserControl
    {
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
            nameof(IsReadOnly),
            propertyType: typeof(bool),
            ownerType: typeof(Float3Box),
            new PropertyMetadata(defaultValue: false));

        public static readonly DependencyProperty ValueXProperty = DependencyProperty.Register(
            nameof(ValueX),
            propertyType: typeof(float),
            ownerType: typeof(Float3Box),
            new FrameworkPropertyMetadata(defaultValue: 0f,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty ValueYProperty = DependencyProperty.Register(
            nameof(ValueY),
            propertyType: typeof(float),
            ownerType: typeof(Float3Box),
            new FrameworkPropertyMetadata(defaultValue: 0f,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty ValueZProperty = DependencyProperty.Register(
            nameof(ValueZ),
            propertyType: typeof(float),
            ownerType: typeof(Float3Box),
            new FrameworkPropertyMetadata(defaultValue: 0f,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public float ValueX
        {
            get => (float)GetValue(ValueXProperty);
            set => SetValue(ValueXProperty, value);
        }

        public float ValueY
        {
            get => (float)GetValue(ValueYProperty);
            set => SetValue(ValueYProperty, value);
        }

        public float ValueZ
        {
            get => (float)GetValue(ValueZProperty);
            set => SetValue(ValueZProperty, value);
        }

        public Float3Box()
        {
            InitializeComponent();
        }
    }
}
