using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Dirt3TelemetryDisplay.Controls;

namespace Dirt3TelemetryDisplay
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int telemetryPort = 20777;
        private int uiUpdateIntervalInMilliseconds = 200;

        public event PropertyChangedEventHandler PropertyChanged;

        public int TelemetryPort
        {
            get => telemetryPort;
            set
            {
                telemetryPort = value;
                OnPropertyChanged(nameof(TelemetryPort));
            }
        }

        public int UiUpdateIntervalInMilliseconds
        {
            get => uiUpdateIntervalInMilliseconds;
            set
            {
                uiUpdateIntervalInMilliseconds = value;
                OnPropertyChanged(nameof(UiUpdateIntervalInMilliseconds));
            }
        }

        public void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
