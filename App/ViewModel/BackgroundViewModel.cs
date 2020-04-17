using App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class BackgroundViewModel
    {
        public ObservableCollection<Template> templates;

        public BackgroundViewModel()
        {
            templates = new ObservableCollection<Template>();
            for (int i = 1; i <= 14; i++)
            {
                templates.Add(new Template(string.Format("Template {0}", i), string.Format("Resource/background/{0}.jpg", i)));
            }
        }
    }
}
