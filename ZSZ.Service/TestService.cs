using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service
{
    public class TestService
    {
        public void Test()
        {
            using (MyDbContext db = new MyDbContext())
            {
                Console.WriteLine(db.Settings.Count());
                Console.WriteLine("ok");
            }
        }
    }
}
