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
    /// Interaction logic for InfoItemFloat.xaml
    /// </summary>
    public partial class InfoItemFloat : UserControl
    {
        public static readonly DependencyProperty BytesRangeStartProperty = DependencyProperty.Register(
            nameof(BytesRangeStart),
            propertyType: typeof(int),
            ownerType: typeof(InfoItemFloat),
            new PropertyMetadata(defaultValue: 0));

        public static readonly DependencyProperty BytesRangeEndProperty = DependencyProperty.Register(
            nameof(BytesRangeEnd),
            propertyType: typeof(int),
            ownerType: typeof(InfoItemFloat),
            new PropertyMetadata(defaultValue: DataConverter.FloatSize));

        public static readonly DependencyProperty FieldNameProperty = DependencyProperty.Register(
            nameof(FieldName),
            propertyType: typeof(string),
            ownerType: typeof(InfoItemFloat),
            new PropertyMetadata(defaultValue: "Unknown"));

        public static readonly DependencyProperty FieldValueProperty = DependencyProperty.Register(
            nameof(FieldValue),
            propertyType: typeof(float),
            ownerType: typeof(InfoItemFloat),
            new PropertyMetadata(defaultValue: 0f));

        public int BytesRangeStart
        {
            get => (int)GetValue(BytesRangeStartProperty);
            set => SetValue(BytesRangeStartProperty, value);
        }

        public int BytesRangeEnd
        {
            get => (int)GetValue(BytesRangeEndProperty);
            set => SetValue(BytesRangeEndProperty, value);
        }

        public string FieldName
        {
            get => (string)GetValue(FieldNameProperty);
            set => SetValue(FieldNameProperty, value);
        }

        public float FieldValue
        {
            get => (float)GetValue(FieldValueProperty);
            set => SetValue(FieldValueProperty, value);
        }

        public InfoItemFloat()
        {
            InitializeComponent();
        }
    }
}
