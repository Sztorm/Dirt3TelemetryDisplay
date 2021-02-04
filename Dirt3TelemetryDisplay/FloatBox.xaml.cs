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
    /// Interaction logic for FloatBox.xaml
    /// </summary>
    public partial class FloatBox : UserControl
    {
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
            nameof(IsReadOnly),
            propertyType: typeof(bool),
            ownerType: typeof(FloatBox),
            new PropertyMetadata(defaultValue: false));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            propertyType: typeof(float),
            ownerType: typeof(FloatBox),
            new PropertyMetadata(defaultValue: 0f));

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public float Value
        {
            get => (float)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public FloatBox()
        {
            InitializeComponent();    
        }
    }
}
