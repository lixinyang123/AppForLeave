using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class FeedBackPage : Page
    {
        public FeedBackPage()
        {
            this.InitializeComponent();
            //ShowStatusBar();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //复制到剪切板
            var dp = new DataPackage();
            dp.SetText(txtbox.Text);
            Clipboard.SetContent(dp);
            //显示状态文本
            txt_successful.Visibility = Visibility.Visible;
        }

        //显示手机导航栏
        //private async void ShowStatusBar()
        //{
        //    if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
        //    {
        //        var statusbar = StatusBar.GetForCurrentView();
        //        await statusbar.ShowAsync();
        //        statusbar.BackgroundColor = Colors.Black;
        //        statusbar.BackgroundOpacity = 1;
        //        statusbar.ForegroundColor = Colors.White;
        //    }
        //}

        #region 控件交互

        //返回主页
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("https://mp.weixin.qq.com/s?__biz=MzU1OTYwNzQ2NQ==&mid=2247483656&idx=1&sn=c74f7c73088b1fd86c1d13ea36f73a1f&chksm=fc15facecb6273d8725e6dc1096c3b3afed803a930e431d49247c307cd59877e1bd5acb64f2d&scene=0#rd");
            await Launcher.LaunchUriAsync(uri);
        }

        #endregion

    }
}
