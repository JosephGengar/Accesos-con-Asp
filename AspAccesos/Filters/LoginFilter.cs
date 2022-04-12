using AspAccesos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspAccesos.Filters
{
    public class LoginFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = HttpContext.Current.Session["user"];
            if (oUser == null)
            {
                if (filterContext.Controller is RegistrosController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/User/Index");
                }
            }
            else
            {
                if (filterContext.Controller is UserController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Registros/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}