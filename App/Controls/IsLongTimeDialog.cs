using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace App.Controls
{
    public class IsLongTimeDialog : ContentDialog
    {
        public IsLongTimeDialog()
        {
            this.Title = "是否生成长期假条";
            this.Content = "长期假条为3天\n普通假条为1天";
            this.CloseButtonText = "长期";
            this.PrimaryButtonText = "普通";
            this.DefaultButton = ContentDialogButton.Primary;
        }
    }
}
