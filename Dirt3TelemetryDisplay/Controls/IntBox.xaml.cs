using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for IntBox.xaml
    /// </summary>
    public partial class IntBox : UserControl
    {
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
            nameof(IsReadOnly),
            propertyType: typeof(bool),
            ownerType: typeof(IntBox),
            new FrameworkPropertyMetadata(defaultValue: false,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MaxTextLengthProperty = DependencyProperty.Register(
            nameof(MaxTextLength),
            propertyType: typeof(int),
            ownerType: typeof(IntBox),
            new FrameworkPropertyMetadata(defaultValue: 0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            propertyType: typeof(int),
            ownerType: typeof(IntBox), 
            new FrameworkPropertyMetadata(defaultValue: 0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            nameof(MinValue),
            propertyType: typeof(int),
            ownerType: typeof(IntBox),
            new FrameworkPropertyMetadata(defaultValue: int.MinValue,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            propertyType: typeof(int),
            ownerType: typeof(IntBox),
            new FrameworkPropertyMetadata(defaultValue: int.MaxValue,
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

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public int MinValue
        {
            get => (int)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public IntBox()
        {
            InitializeComponent();
        }
    }
}
