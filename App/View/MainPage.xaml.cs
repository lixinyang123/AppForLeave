using App.Controls;
using App.Model;
using App.Style;
using App.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
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
    public sealed partial class MainPage : Page
    {
        #region ViewModel

        private UserViewModel userViewModel;
        private EventViewModel eventViewModel;
        private BackgroundViewModel backgroundViewModel;

        #endregion

        /// <summary>
        /// 所需提示弹框
        /// </summary>
        #region
        private IsLongTimeDialog isLongTimeDialong = new IsLongTimeDialog();
        private CheckDataDialog checkDataDialong;
        #endregion

        /// <summary>
        /// 页面传递参数
        /// </summary>
        private Arg arg;

        public MainPage()
        {
            this.InitializeComponent();

            arg = new Arg();

            InitializeBindingSource();
            InitializeDateTemplate();
            //ShowStatusBar();
            SetTitleBar();
            InitControlEvent();

            InitAcrylicBrush();
        }

        #region 资源初始化

        /// <summary>
        /// 初始化特效
        /// </summary>
        private void InitAcrylicBrush()
        {
            MyAcrylicBrush.InitializeFrostedGlass(glassHost);
            btn_AcrylicBrush.IsOn = (bool)ApplicationData.Current.LocalSettings.Values["IsUseAcrylicBrush"];
            txt_restart.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 初始化数据绑定资源
        /// </summary>
        private void InitializeBindingSource()
        {
            userViewModel = new UserViewModel();
            eventViewModel = new EventViewModel();
            backgroundViewModel = new BackgroundViewModel();
        }

        /// <summary>
        /// 初始化日期选择控件
        /// </summary>
        private void InitializeDateTemplate()
        {
            datepicker.MinYear = DateTimeOffset.Now;
            datepicker.MaxYear = DateTimeOffset.Parse("12/31/2020");
            datepicker.SelectedDate = DateTimeOffset.Now;
        }

        /// <summary>
        /// 显示手机导航栏
        /// </summary>
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

        /// <summary>
        /// 界面扩展到标题栏
        /// </summary>
        private void SetTitleBar()
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            var titlebar = ApplicationView.GetForCurrentView().TitleBar;
            titlebar.ButtonBackgroundColor = Colors.Transparent;
        }

        /// <summary>
        /// 初始化提示界面事件
        /// </summary>
        private void InitControlEvent()
        {
            isLongTimeDialong.CloseButtonClick += new TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs>(IsLongTimeClose);
            isLongTimeDialong.PrimaryButtonClick += new TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs>(IsLongTimePrimary);
        }

        #endregion


        #region 控件交互

        /// <summary>
        /// 文本改变时自动提示
        /// </summary>
        private void autoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var list = userViewModel.users.Where(i => i.Name.StartsWith(autoSuggestBox.Text)).Select(i => i.Name).ToList();
            autoSuggestBox.ItemsSource = list;
        }

        /// <summary>
        /// 毛玻璃特效开关
        /// </summary>
        private void btn_AcrylicBrush_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["IsUseAcrylicBrush"] = btn_AcrylicBrush.IsOn;
            txt_restart.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 模板预览界面开关
        /// </summary>
        private void btn_template_Click(object sender, RoutedEventArgs e)
        {
            mysplitview.IsPaneOpen = !mysplitview.IsPaneOpen;
        }

        /// <summary>
        /// 按性别筛选名单
        /// </summary>
        private void btn_SelectSex(object sender, RoutedEventArgs e)
        {
            userViewModel.users.Clear();
            btn_all.IsChecked = false;
            btn_f.IsChecked = false;
            btn_m.IsChecked = false;

            (sender as ToggleButton).IsChecked = true;
            List<User> list = new List<User>();
            var temp = new UserViewModel().users;
            if (btn_f.IsChecked == true)
            {
                list = temp.Where(i => i.Sex == SEX.f).ToList();
            }
            else if (btn_m.IsChecked == true)
            {
                list = temp.Where(i => i.Sex == SEX.m).ToList();
            }
            else
            {
                list = temp.ToList();
            }

            foreach (var li in list)
            {
                userViewModel.users.Add(li);
            }
            list.Clear();

        }

        /// <summary>
        /// 按钮点击事件（导航到假条保存界面）
        /// </summary>
        private async void button_ok_Click(object sender, RoutedEventArgs e)
        {
            SetArg();
            if (CheckArg() == true)
            {
                if (IsFinished())
                {
                    await isLongTimeDialong.ShowAsync();
                }
                else
                {
                    checkDataDialong = new CheckDataDialog(arg);
                    checkDataDialong.PrimaryButtonClick += new TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs>(CheckDate_PrimaryButton);
                    await checkDataDialong.ShowAsync();
                    await isLongTimeDialong.ShowAsync();
                }
            }
            else
            {
                //重置参数
                arg = new Arg();

                //显示ContentDialog
                var warningDialog = new WarningDialog();
                await warningDialog.ShowAsync();
            }
        }

        /// <summary>
        /// 搜索建议提交
        /// </summary>
        private void autoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            foreach (var item in ListView.Items)
            {
                string a = (item as User).Name;
                if (a == args.QueryText)
                {
                    ListView.SelectedItem = item;
                }
            }
        }

        /// <summary>
        /// 获取用户选择模板
        /// </summary>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            arg.template = e.ClickedItem as Template;
            mysplitview.IsPaneOpen = !mysplitview.IsPaneOpen;
            //设置显示
            btn_template.Content = arg.template.Name;
        }

        /// <summary>
        /// 向开发者反馈
        /// </summary>
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FeedBackPage));
        }

        #endregion


        #region 业务逻辑

        /// <summary>
        /// 设置传递信息
        /// </summary>
        public void SetArg()
        {
            //设置参数中的用户的基本信息
            GetUser();
            //设置参数中的用户选择日期
            GetDate();
            //设置参数中的用户去向
            GetAdress();
        }

        /// <summary>
        /// 检测参数格式是否正确
        /// </summary>
        /// <returns></returns>
        public bool CheckArg()
        {
            bool result = false;
            if (arg.user != null && arg.template != null && arg.myEvent != null)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 判断日期是否有可能选错
        /// </summary>
        private bool IsFinished()
        {
            bool result = true;
            DateTime dt = DateTime.Now;
            if (dt.Hour >= 21 && arg.dateTime.Day == dt.Day)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 获取选择的用户的基本信息
        /// </summary>
        public void GetUser()
        {
            if (ListView.SelectedItem != null)
            {
                foreach (User user in userViewModel.users)
                {
                    if (user.Name == userViewModel.users[ListView.SelectedIndex].Name)
                    {
                        arg.user = user;
                    }
                }
            }
        }

        /// <summary>
        /// 获取用户选择去向
        /// </summary>
        private void GetAdress()
        {
            if (combobox2.SelectedItem != null)
            {
                arg.myEvent = new EventViewModel().myevents[combobox2.SelectedIndex];
            }
        }

        /// <summary>
        /// 获取用户选择的日期
        /// </summary>
        private void GetDate()
        {
            arg.dateTime = datepicker.Date;
        }

        /// <summary>
        /// 检查日期对话框中的事件
        /// </summary>
        private void CheckDate_PrimaryButton(ContentDialog sender, ContentDialogButtonClickEventArgs e)
        {
            arg.dateTime = datepicker.Date.AddDays(1);
        }

        /// <summary>
        /// 不生成长期假条
        /// </summary>
        private void IsLongTimePrimary(ContentDialog sender, ContentDialogButtonClickEventArgs e)
        {
            arg.SpendTime = 0;
            Frame.Navigate(typeof(BlankPage1), arg);
        }

        /// <summary>
        /// 生成长期假条
        /// </summary>
        private void IsLongTimeClose(ContentDialog sender, ContentDialogButtonClickEventArgs e)
        {
            arg.SpendTime = 2;
            Frame.Navigate(typeof(BlankPage1), arg);
        }

        #endregion


    }
}
