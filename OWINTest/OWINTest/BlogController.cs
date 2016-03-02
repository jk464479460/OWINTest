using System.Collections.Generic;
using System.Web.Http;

namespace OWINTest
{
    public class BlogController:ApiController
    {
        string[] app=new string[] { "linezero", "wuxiaoyan"};
        public IEnumerable<string> Get()
        {
            return app;
        }
        public string Get(int id)
        {
            return $"owin {app[id]} by:linezero";
        }
        public void Post([FromBody]string value)
        {
            app[0] = "valuePost";
        }
        public void Put(int id,[FromBody]string value)
        {
            app[id] = "Put";
        }
        public void Delete(int id)
        {
            app[id] = "null";
        }
    }
}
