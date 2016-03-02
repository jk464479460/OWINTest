using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace OWINTest
{
    public class SampleMiddleware:OwinMiddleware
    {
        private object _mOptions;

        public SampleMiddleware(OwinMiddleware next,object options) : base(next)
        {
            _mOptions = options;
        }

        public override Task Invoke(IOwinContext context)
        {
            PathString tickPath = new PathString("/tick");
            //判断Request路径为/tick开头
            if (context.Request.Path.StartsWithSegments(tickPath))
            {
                string content = DateTime.Now.Ticks.ToString();
                //输出答案--当前的Tick数字
                context.Response.ContentType = "text/plain";
                context.Response.ContentLength = content.Length;
                context.Response.StatusCode = 200;
                context.Response.Expires = DateTimeOffset.Now;
                context.Response.Write(content);
                //解答者告诉Server解答已经完毕,后续Middleware不需要处理
                return Task.FromResult(0);
            }
            else
                //中间件的实现代码
                return Next.Invoke(context);
        }
    }
}
