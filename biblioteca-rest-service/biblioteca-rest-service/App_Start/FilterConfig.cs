﻿using System.Web;
using System.Web.Mvc;

namespace biblioteca_rest_service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
