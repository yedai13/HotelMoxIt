using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WEB.Filters
{
    public class EsAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetInt32("UserExist") != 1)
            {
                context.Result = new RedirectResult("/Usuario/Login");
                return;
            }

            if (context.HttpContext.Session.GetInt32("TipoUsuario") != 2)
            {
                context.Result = new RedirectResult("/Habitaciones");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
