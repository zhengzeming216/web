using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIBLL
{
    public interface IUserBLL
    {
        bool Check(string name, string pwd);
        void Add(string name, string pwd);
    }
}
