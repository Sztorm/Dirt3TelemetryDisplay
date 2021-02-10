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
            new FrameworkPropertyMetadata(defaultValue: false,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MaxTextLengthProperty = DependencyProperty.Register(
            nameof(MaxTextLength),
            propertyType: typeof(int),
            ownerType: typeof(FloatBox),
            new FrameworkPropertyMetadata(defaultValue: 0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            propertyType: typeof(float),
            ownerType: typeof(FloatBox),
            new FrameworkPropertyMetadata(defaultValue: 0f,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public int MaxTextLength
        {
            get => (int)GetValue(MaxTextLengthProperty);
            set => SetValue(MaxTextLengthProperty, value);
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
