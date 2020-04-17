using App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class UserViewModel
    {
        public ObservableCollection<User> users;

        public UserViewModel()
        {
            users = new ObservableCollection<User>();

            #region 男
            users.Add(new User("李新阳", "Resource/name/lxy.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("孙迎晨", "Resource/name/syc.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("魏嘉琛", "Resource/name/wjc.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("赵恩奇", "Resource/name/zeq.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("刘洋", "Resource/name/ly.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("刘鸿菲", "Resource/name/lhf.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("程远航", "Resource/name/cyh.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("王天星", "Resource/name/wtx.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("张少孔", "Resource/name/zsk.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("刘凯", "Resource/name/lk.png", SEX.m, "jw1701", "ljs"));
            users.Add(new User("李超", "Resource/name/lc.png", SEX.m, "rj1701", "lw"));
            users.Add(new User("石亚新", "Resource/name/syx.png", SEX.m, "rj1708", "wjm"));
            users.Add(new User("梅启峰", "Resource/name/mqf.png", SEX.m, "rj1708", "wjm"));
            users.Add(new User("李克楠", "Resource/name/lkn.png", SEX.m, "rj1706", "ycy"));
            users.Add(new User("高龙博", "Resource/name/glb.png", SEX.m, "dsj1802", "lx"));
            users.Add(new User("赵士皓", "Resource/name/zsh.png", SEX.m, "dsj1802", "lx"));
            users.Add(new User("王金洋", "Resource/name/wjy.png", SEX.m, "dsj1802", "lx"));
            #endregion

            #region 女
            users.Add(new User("朱英鑫", "Resource/name/zyx.png", SEX.f, "rj1701", "lw"));
            users.Add(new User("孟玉", "Resource/name/my.png", SEX.f, "rj1701", "lw"));
            users.Add(new User("闫明珠", "Resource/name/ymz.png", SEX.f, "rj1701", "lw"));
            users.Add(new User("王浏洁", "Resource/name/wlj.png", SEX.f, "rj1701", "lw"));
            users.Add(new User("黄真", "Resource/name/hz.png", SEX.f, "rj1701", "lw"));
            users.Add(new User("丁一杰", "Resource/name/dyj.png", SEX.f, "rj1701", "lw"));
            users.Add(new User("付京华", "Resource/name/fjh.png", SEX.f, "rj1701", "lw"));
            users.Add(new User("朱路路", "Resource/name/zll.png", SEX.f, "jw1701", "ljs"));
            users.Add(new User("蒿莹", "Resource/name/hy.png", SEX.f, "gg1701", "wyl"));
            #endregion
        }
    }
}
