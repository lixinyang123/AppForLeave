using App.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class BlankPage2 : Page
    {
        public BlankPage2()
        {
            this.InitializeComponent();

            MyAcrylicBrush.InitializeFrostedGlass(GlassHost);

            //ShowStatusBar();
            txtblk.Visibility = Visibility.Collapsed;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            txtbox.Text = e.Parameter.ToString();
        }

        #region 控件交互

        //复制地址
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //复制地址
            var dp = new DataPackage();
            dp.SetText(txtbox.Text);
            Clipboard.SetContent(dp);
            //显示提示
            txtblk.Visibility = Visibility.Visible;
        }

        //继续生成按钮
        private void button_continue_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        #endregion

    }
}
