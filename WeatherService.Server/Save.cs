using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WeatherService.DAL;
using WeatherService.Model;

namespace WeatherService.Server
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Save”。
    public class Save : ISave
    {
        private UserDB userDb = new UserDB();
        public void DoWork(User user)
        {
            userDb.Save(user);
        }
    }
}
