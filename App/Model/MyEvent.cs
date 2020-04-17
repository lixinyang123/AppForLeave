using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    /// <summary>
    /// 请假事件
    /// </summary>
    public class MyEvent
    {
        public MyEvent(Reason re, Address ad)
        {
            reason = re;
            address = ad;
        }

        /// <summary>
        /// 请假原因
        /// </summary>
        public Reason reason { get; set; }

        /// <summary>
        /// 请假去向
        /// </summary>
        public Address address { get; set; }
    }
}
