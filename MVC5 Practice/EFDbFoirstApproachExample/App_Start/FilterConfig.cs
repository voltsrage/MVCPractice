﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFoirstApproachExample.Filters;

namespace EFDbFoirstApproachExample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new MyExceptionFilter());
            filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(Exception),View="Error"});
        }
    }
}