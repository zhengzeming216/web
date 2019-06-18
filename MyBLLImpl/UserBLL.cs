using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyIBLL;

namespace MyBLLImpl
{
    public class UserBLL : IUserBLL
    {
        public void Add(string name, string pwd)
        {
            Console.WriteLine("添加用户："+name);
        }

        public bool Check(string name, string pwd)
        {
            Console.WriteLine("检查用户："+name+"，密码："+pwd);
            return true;
        }
    }
}
