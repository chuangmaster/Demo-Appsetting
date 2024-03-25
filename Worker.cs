using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Appsetting
{
    interface IWorker
    {
        void Run();
    }
    internal class Worker : IWorker
    {
        public IConfiguration _Configuration { get; set; }
        public Worker(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public void Run()
        {
            Console.WriteLine("Work Hard");
            Console.WriteLine($"{_Configuration["Key"]}");

            //foreach (var config in _Configuration.AsEnumerable())
            //{
            //    Console.WriteLine($"{config.Key}: {config.Value}");
            //}
        }
    }
}
