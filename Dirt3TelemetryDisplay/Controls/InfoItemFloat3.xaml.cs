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
    /// Interaction logic for InfoItemFloat3.xaml
    /// </summary>
    public partial class InfoItemFloat3 : UserControl
    {
        public static readonly DependencyProperty BytesRangeStartProperty = DependencyProperty.Register(
            nameof(BytesRangeStart),
            propertyType: typeof(int),
            ownerType: typeof(InfoItemFloat3),
            new PropertyMetadata(0));

        public static readonly DependencyProperty BytesRangeEndProperty = DependencyProperty.Register(
            nameof(BytesRangeEnd),
            propertyType: typeof(int),
            ownerType: typeof(InfoItemFloat3),
            new PropertyMetadata(defaultValue: DataConverter.Float3Size));

        public static readonly DependencyProperty FieldNameProperty = DependencyProperty.Register(
            nameof(FieldName),
            propertyType: typeof(string),
            ownerType: typeof(InfoItemFloat3),
            new PropertyMetadata("Unknown"));

        public static readonly DependencyProperty FieldValueXProperty = DependencyProperty.Register(
            nameof(FieldValueX),
            propertyType: typeof(float),
            ownerType: typeof(InfoItemFloat3),
            new PropertyMetadata(0f));

        public static readonly DependencyProperty FieldValueYProperty = DependencyProperty.Register(
            nameof(FieldValueY),
            propertyType: typeof(float),
            ownerType: typeof(InfoItemFloat3),
            new PropertyMetadata(0f));

        public static readonly DependencyProperty FieldValueZProperty = DependencyProperty.Register(
            nameof(FieldValueZ),
            propertyType: typeof(float),
            ownerType: typeof(InfoItemFloat3),
            new PropertyMetadata(0f));

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

        public float FieldValueX
        {
            get => (float)GetValue(FieldValueXProperty);
            set => SetValue(FieldValueXProperty, value);
        }

        public float FieldValueY
        {
            get => (float)GetValue(FieldValueYProperty);
            set => SetValue(FieldValueYProperty, value);
        }

        public float FieldValueZ
        {
            get => (float)GetValue(FieldValueZProperty);
            set => SetValue(FieldValueZProperty, value);
        }

        public InfoItemFloat3()
        {
            InitializeComponent();
        }
    }
}
