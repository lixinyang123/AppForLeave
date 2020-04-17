using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    /// <summary>
    /// 假条模板
    /// </summary>
    public class Template : BaseTamplate
    {
        public Template(string name, string source)
        {
            Name = name;
            Source = source;
        }
    }
}
