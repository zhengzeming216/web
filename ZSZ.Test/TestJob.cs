using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Test
{
    class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("任务已执行"+DateTime.Now);
        }
    }
}
