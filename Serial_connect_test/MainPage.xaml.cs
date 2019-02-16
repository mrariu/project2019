using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Maker.Serial;
using Microsoft.Maker.RemoteWiring;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace Serial_connect_test
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
		//private Microsoft.Maker.RemoteWiring.RemoteDevice device;
		//private Windows.System.Threading.ThreadPoolTimer timer;

		//UsbSerial connection;
		//RemoteDevice arduino;
		//UInt16 lastvalue

		SerialDevice device;

		public MainPage()
        {
            this.InitializeComponent();


			/*
			connection = new UsbSerial("VID_2341", "PID_0043");
			arduino = new RemoteDevice(connection);
			connection.ConnectionEstablished += DeviceReady;

			connection.begin(57600, Microsoft.Maker.Serial.SerialConfig.SERIAL_8N1);
			*/
		}

		private void DeviceReady()
		{
			//arduino.pinMode(13, PinMode.OUTPUT);
			
		}


		private  async void Setting_Click(object sender, RoutedEventArgs e)
		{
			//this.Frame.Navigate(typeof(BlankPage1));
			string portName = "COM3";
			string aqs = SerialDevice.GetDeviceSelector(portName);

			var myDevices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(aqs, null);

			if (myDevices.Count == 0)
			{
				return;
			}

			device = await SerialDevice.FromIdAsync(myDevices[0].Id);
			device.BaudRate = 9600;
			device.DataBits = 8;
			device.StopBits = SerialStopBitCount.One;
			device.Parity = SerialParity.None;
			device.Handshake = SerialHandshake.None;
			device.ReadTimeout = TimeSpan.FromMilliseconds(1000);

			port_value.Text = portName;





		}

		private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}

		private async void Connect_button_Click(object sender, RoutedEventArgs e)
		{
			//arduino.digitalWrite(13, PinState.HIGH);
			DataReader dataReaderObject = new DataReader(device.InputStream);
			await dataReaderObject.LoadAsync(128);
			uint bytesToRead = dataReaderObject.UnconsumedBufferLength;
			string receivedStrings = dataReaderObject.ReadString(bytesToRead);
			string[] val = receivedStrings.Split(',');
			value.Text = val[0];

			
		}
	}
}
