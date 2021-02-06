using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int TelemetryDataLength = 152;

        private readonly MainWindowViewModel viewModel;
        private readonly byte[] telemetryData;
        private readonly DispatcherTimer timer;
        private readonly IPEndPoint listenerEndPoint;
        private Task updateDataTask;
        private volatile bool isListening;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainWindowViewModel)Resources["MainWindowViewModel"];
            telemetryData = new byte[TelemetryDataLength];
            listenerEndPoint = new IPEndPoint(IPAddress.Loopback, viewModel.TelemetryPort);
            timer = new DispatcherTimer();
            timer.Tick += OnTimerTick;  
            btnStart.Click += OnStart;
            btnStop.Click += OnStop;
        }

        private void OnStart(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = Visibility.Hidden;
            btnStop.Visibility = Visibility.Visible;
            btnStop.IsEnabled = false;
            controlsGroupUiUpdateInterval.IsEnabled = false;
            controlsGroupTelemetryPort.IsEnabled = false;

            timer.Interval = TimeSpan.FromMilliseconds(viewModel.UiUpdateIntervalInMilliseconds);
            listenerEndPoint.Port = viewModel.TelemetryPort;

            isListening = true;
            updateDataTask = Task.Run(() => UpdateData(listenerEndPoint));
            timer.Start();
            btnStop.IsEnabled = true;
        }

        private async void OnStop(object sender, RoutedEventArgs e)
        {
            btnStop.IsEnabled = false;
            isListening = false;

            timer.Stop();
            await updateDataTask;

            btnStop.Visibility = Visibility.Hidden;
            btnStart.Visibility = Visibility.Visible;
            controlsGroupUiUpdateInterval.IsEnabled = true;
            controlsGroupTelemetryPort.IsEnabled = true;
        }

        private async void UpdateData(IPEndPoint endPoint)
        {
            var telemetryListener = new UdpClient();

            try
            {
                InitializeUDPListener(telemetryListener, endPoint);

                while (isListening)
                {
                    UdpReceiveResult result = await telemetryListener.ReceiveAsync();

                    if (result.Buffer.Length < TelemetryDataLength)
                    {
                        continue;
                    }
                    result.Buffer.AsSpan(0..TelemetryDataLength).CopyTo(telemetryData);
                }
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode != (int)SocketError.TimedOut)
                {
                    MessageBox.Show(
                        ex.Message, 
                        caption: "UDP error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            finally
            {
                telemetryListener.Client.Shutdown(SocketShutdown.Both);
                telemetryListener.Client.Close();
            }
        }

        private void InitializeUDPListener(UdpClient udpClient, IPEndPoint endPoint)
        {
            udpClient.Client = new Socket(endPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.Client.Bind(endPoint);
            udpClient.Client.ReceiveTimeout = 1000;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            var dataConverter = new DataConverter(telemetryData);
            ItemCollection items = infoItems.Items;
            int index = 0;

            foreach(object item in items)
            {
                if (item is InfoItemFloat infoItemFloat)
                {
                    infoItemFloat.FieldValue = dataConverter.ToFloat(index);
                    index += DataConverter.FloatSize;
                }
                else if (item is InfoItemFloat2 infoItemFloat2)
                {
                    (float x, float y) = dataConverter.ToFloat2(index);
                    infoItemFloat2.FieldValueX = x;
                    infoItemFloat2.FieldValueY = y;
                    index += DataConverter.Float2Size;
                }
                else if (item is InfoItemFloat3 infoItemFloat3)
                {
                    (float x, float y, float z) = dataConverter.ToFloat3(index);
                    infoItemFloat3.FieldValueX = x;
                    infoItemFloat3.FieldValueY = y;
                    infoItemFloat3.FieldValueZ = z;
                    index += DataConverter.Float3Size;
                }
                else if (item is InfoItemFloat4 infoItemFloat4)
                {
                    (float x, float y, float z, float w) = dataConverter.ToFloat4(index);
                    infoItemFloat4.FieldValueX = x;
                    infoItemFloat4.FieldValueY = y;
                    infoItemFloat4.FieldValueZ = z;
                    infoItemFloat4.FieldValueW = w;
                    index += DataConverter.Float4Size;
                }
                if (index >= TelemetryDataLength)
                {
                    return;
                }
            }
        }
    }
}
