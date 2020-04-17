using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum SEX { m, f }

    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户初始化
        /// </summary>
        public User(string name, string signature, SEX sex, string bj, string teacher)
        {
            Name = name;
            Signature = signature;
            Sex = sex;
            Class = bj;
            Teacher = teacher;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 签名图片
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public SEX Sex { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 老师
        /// </summary>
        public string Teacher { get; set; }
    }
}
