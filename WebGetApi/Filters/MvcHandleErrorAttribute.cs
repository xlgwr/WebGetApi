using Common.Logging;
//using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGetApi.Filters
{
    public class MvcHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ILog log = LogManager.GetLogger(filterContext.RequestContext.HttpContext.Request.Url.LocalPath);
            log.Error(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}