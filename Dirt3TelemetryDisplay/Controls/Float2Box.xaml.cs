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
    /// Interaction logic for Float2Box.xaml
    /// </summary>
    public partial class Float2Box : UserControl
    {
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
            nameof(IsReadOnly),
            propertyType: typeof(bool),
            ownerType: typeof(Float2Box),
            new PropertyMetadata(defaultValue: false));

        public static readonly DependencyProperty ValueXProperty = DependencyProperty.Register(
            nameof(ValueX), 
            propertyType: typeof(float), 
            ownerType: typeof(Float2Box),
            new FrameworkPropertyMetadata(defaultValue: 0f,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty ValueYProperty = DependencyProperty.Register(
            nameof(ValueY),
            propertyType: typeof(float),
            ownerType: typeof(Float2Box),
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

        public Float2Box()
        {
            InitializeComponent();
        }
    }
}
