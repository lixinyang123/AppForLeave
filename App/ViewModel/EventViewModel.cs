using App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class EventViewModel
    {
        public ObservableCollection<MyEvent> myevents;

        public ObservableCollection<string> myReasons => GetReason();

        public EventViewModel()
        {
            myevents = new ObservableCollection<MyEvent>();
            myevents.Add(new MyEvent(new Reason("发烧", "resource/myevent/reason/fs.png"), new Address("宿舍休息", "resource/myevent/address/ssxx.png")));
            myevents.Add(new MyEvent(new Reason("生病", "resource/myevent/reason/sb.png"), new Address("市区医院", "resource/myevent/address/sqyy.png")));
            myevents.Add(new MyEvent(new Reason("家中有事", "resource/myevent/reason/ys.png"), new Address("回家", "resource/myevent/address/hj.png")));
            myevents.Add(new MyEvent(new Reason("摔伤", "resource/myevent/reason/ss.png"), new Address("宿舍", "resource/myevent/address/ss.png")));
            myevents.Add(new MyEvent(new Reason("胃炎", "resource/myevent/reason/wy.png"), new Address("宿舍", "resource/myevent/address/yy.png")));
        }

        private ObservableCollection<string> GetReason()
        {
            ObservableCollection<string> myreasons = new ObservableCollection<string>();
            foreach (var item in myevents)
            {
                myreasons.Add(item.reason.Name);
            }
            return myreasons;
        }
    }
}
