﻿using System.Web;
using System.Web.Mvc;
using WebGetApi.Filters;

namespace WebGetApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MvcHandleErrorAttribute());
        }
    }
}