using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System;

namespace OWINTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = "http://localhost:9001";
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("exit by any key");
            Console.ReadLine();
        }
    }
}
