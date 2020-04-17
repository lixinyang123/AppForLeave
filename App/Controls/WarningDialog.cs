using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace App.Controls
{
    public class WarningDialog : ContentDialog
    {
        public WarningDialog()
        {
            this.Title = "注意";
            this.Content = "请完善全部信息";
            this.CloseButtonText = "确定";
        }
    }
}
