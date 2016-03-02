using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_sync
{
    class Program
    {
        static IDictionary<int,int> _dict=new Dictionary<int, int>();  
        static void Main(string[] args)
        {
            var my=new MyClass();
            my.DoSthAsync();
            var my2 = new MyClass2();
            var r=my2.DosmAsync();
            Console.WriteLine(r.Result);
        }
        //自己写异步代码
        class MyClass
        {
            private Task<int> GetValueAsync(int n, int m)
            {
                Thread.Sleep(5000);
                return Task.Run(() => n + m);
            } 
            public async void DoSthAsync()
            {
                int result = await GetValueAsync(1,2);//开辟新线程执行
                //异步委托执行后续代码
                Debug.WriteLine("yes i first run");
                Debug.WriteLine(result);//等待最终结果
            } 
        }

        class MyClass2
        {
            public Task<int> DosmAsync()
            {
                var result = 1;
                return Task.FromResult(result);//返回一个带值的异步结果
            } 
        }

    }
}
