using System.Windows;

namespace Dirt3TelemetryDisplay.Controls
{
    public class RangeIntDependency : DependencyObject
    {
        public static readonly DependencyProperty MinProperty = DependencyProperty.Register(
            nameof(Min),
            propertyType: typeof(int),
            ownerType: typeof(RangeIntDependency),
            new FrameworkPropertyMetadata(
                defaultValue: 0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MaxProperty = DependencyProperty.Register(
            nameof(Max),
            propertyType: typeof(int),
            ownerType: typeof(RangeIntDependency),
            new FrameworkPropertyMetadata(
                defaultValue: 0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }
    }
}
