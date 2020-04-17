using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class Arg
    {
        public Template template { get; set; }
        public User user { get; set; }
        public MyEvent myEvent { get; set; }
        public DateTimeOffset dateTime { get; set; }
        public int SpendTime { get; set; }
    }
}
