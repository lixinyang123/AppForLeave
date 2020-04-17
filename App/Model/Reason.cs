using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    /// <summary>
    /// 请假原因
    /// </summary>
    public class Reason : BaseTamplate
    {
        public Reason(string name, string source)
        {
            Name = name;
            Source = source;
        }
    }
}
