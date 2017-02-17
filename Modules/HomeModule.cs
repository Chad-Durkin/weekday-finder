using Nancy;
using System.Collections.Generic;
using WeekdayApp.Objects;

namespace WeekdayApp
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };
        }
    }
}
