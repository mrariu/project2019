/***************************************************************************************/
/*project_2019_avionics
 * 製作者：村上瑠(Twitter：@MURakami_bird)
 * 
 * 搭載機器：回転数計、高度計、対気速度計、
 * 
 * 操舵システム：FBW（wiiヌンチャク⇔Arduino⇔LTC485CN8⇔RS405CB(right)・RS406CB(left）)
 * 
 * システム概要
 * 
 * windows_10_mobile------Arduino-----------CNZ1023(フォトインタラプタ)
 *                    |                  |
 *                    |--ジャイロセンサ  |--HC-SR04(超音波センサ)
 *                    |                  |
 *                     --GPSセンサ        --MPXV7002DP(差圧センサ)
 *        
 *                                  
 *                                  
 ***************************************************************************************/



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

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace Cake1
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Cadence_val_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}
	}
}
