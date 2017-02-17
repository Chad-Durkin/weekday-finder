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
            Post["/weekday"] = _ => {
              Weekday newWeekDay = new Weekday(
              Request.Form["month"],
              Request.Form["day"],
              Request.Form["year"]);
              return View["weekday.cshtml", newWeekDay];
            };
        }
    }
}
