using App.Model;
using App.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        private Arg arg;
        DateTimeOffset dt_return;

        #region 数据绑定所需信息
        private string Image_sex;
        private string Image_class;
        private string Image_teacher;
        private string Image_leaveyear;
        private string Image_leavemonth;
        private string Image_leaveday;
        private string Image_returnyear;
        private string Image_returnmonth;
        private string Image_returnday;
        #endregion

        public BlankPage1()
        {
            this.InitializeComponent();

            MyAcrylicBrush.InitializeFrostedGlass(GlassHost);

            //ShowStatusBar();
            arg = new Arg();
        }

        #region 页面初始化

        /// <summary>
        /// 导航到时执行
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            arg = (Arg)e.Parameter;
            SetReturnTime();
            SetBindSource();
        }


        /// <summary>
        /// 显示手机导航栏
        /// </summary>
        //private async void ShowStatusBar()
        //{
        //    新版SDK已经不支持 Windows Phone
        //    if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
        //    {
        //        var statusbar = StatusBar.GetForCurrentView();
        //        await statusbar.ShowAsync();
        //        statusbar.BackgroundColor = Colors.Black;
        //        statusbar.BackgroundOpacity = 1;
        //        statusbar.ForegroundColor = Colors.White;
        //    }
        //}

        #endregion


        #region 控件交互

        /// <summary>
        /// 点击保存按钮触发事件
        /// </summary>
        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            progressring.IsActive = true;
            string path = await CreatePictureFile();
            progressring.IsActive = false;
            //导航到完成页面
            if (path != null)
            {
                Frame.Navigate(typeof(BlankPage2), path);
            }
        }

        /// <summary>
        /// 返回上一页
        /// </summary>
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        #endregion


        #region 业务逻辑

        /// <summary>
        /// 设置返回日期
        /// </summary>
        private void SetReturnTime()
        {
            dt_return = arg.dateTime.AddDays(arg.SpendTime);
            if (arg.SpendTime != 0)
            {
                var img = new BitmapImage(new Uri("ms-appx:///View/Resource/boss/lh.png", UriKind.Absolute));
                Boss.Source = img;
            }
        }

        /// <summary>
        /// 设置数据绑定所需资源
        /// </summary>
        public void SetBindSource()
        {
            Image_sex = "Resource/sex/" + arg.user.Sex + ".png";
            Image_class = "Resource/class/" + arg.user.Class + ".png";
            Image_teacher = "Resource/teacher/" + arg.user.Teacher + ".png";
            Image_leaveyear = "Resource/year/" + arg.dateTime.Year.ToString() + ".png";
            Image_leavemonth = "Resource/date/" + arg.dateTime.Month.ToString() + ".png";
            Image_leaveday = "Resource/date/" + arg.dateTime.Day.ToString() + ".png";
            Image_returnyear = "Resource/year/" + dt_return.Year.ToString() + ".png";
            Image_returnmonth = "Resource/date/" + dt_return.Month.ToString() + ".png";
            Image_returnday = "Resource/date/" + dt_return.Day.ToString() + ".png";
        }

        /// <summary>
        /// 新建一个图片文件
        /// </summary>
        private async Task<string> CreatePictureFile()
        {
            //定义文件名
            FileSavePicker picker = new FileSavePicker();
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeChoices.Add("Image", new List<string>() { ".jpg" });
            picker.SuggestedFileName = arg.dateTime.Month + "." + arg.dateTime.Day + arg.user.Name + "的假条";

            StorageFile saveFile = await picker.PickSaveFileAsync();

            if (saveFile != null)
            {
                await WriteGridData(saveFile);
                return saveFile.Path;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 向指定的图片文件写入网格信息
        /// </summary>
        private async Task WriteGridData(StorageFile saveFile)
        {
            //获取Grid信息
            RenderTargetBitmap bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(PicGrid);
            //获取像素信息并转化
            var pixelBuffer = await bitmap.GetPixelsAsync();
            using (var fileStream = await saveFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, fileStream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                    BitmapAlphaMode.Ignore,
                     (uint)bitmap.PixelWidth,
                     (uint)bitmap.PixelHeight,
                     DisplayInformation.GetForCurrentView().LogicalDpi,
                     DisplayInformation.GetForCurrentView().LogicalDpi,
                     pixelBuffer.ToArray());
                await encoder.FlushAsync();
            }
        }

        #endregion

    }
}
