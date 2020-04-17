using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace App.Controls
{
    public class CheckDataDialog : ContentDialog
    {
        public CheckDataDialog(Arg arg)
        {
            this.Title = "注意！今天已经没有课程了";
            this.Content = "确定生成" + arg.dateTime.Month + "月" + arg.dateTime.Day + "日" + "（今天）的假条？";
            this.CloseButtonText = "确定";
            this.PrimaryButtonText = string.Format("生成明天的假条");
            this.DefaultButton = ContentDialogButton.Primary;
        }
    }
}
