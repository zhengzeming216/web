using MyIBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBLLImpl
{
    public class DogBLL : IDogBLL
    {
        public void Say()
        {
            Console.WriteLine("汪汪汪");
        }
    }
}
