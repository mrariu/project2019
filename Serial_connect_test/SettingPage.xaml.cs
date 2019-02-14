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
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace Serial_connect_test
{
	/// <summary>
	/// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
	/// </summary>
	public sealed partial class BlankPage1 : Page
	{
		public BlankPage1()
		{
			this.InitializeComponent();
		}

		private void OK_Button_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
		}

		private void Reload_button_Click(object sender, RoutedEventArgs e)
		{
			reload_function();
		}

		private async void reload_function()
		{
			port_name.Items.Clear();

			string aqs = SerialDevice.GetDeviceSelector();
			var deviceCollection = await DeviceInformation.FindAllAsync(aqs);
			List<string> portNamesList = new List<string>();
			foreach (var item in deviceCollection)
			{
				var serialDevice = await SerialDevice.FromIdAsync(item.Id);
				var portName = serialDevice.PortName;
				port_name.Items.Add(portName);
			}
		}
	}
}
