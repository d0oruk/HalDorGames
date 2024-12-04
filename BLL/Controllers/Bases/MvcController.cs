using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers.Bases
{
    public abstract class MvcController : Controller
    {
        protected MvcController()
        {
            //THIS CODE BLOCK SHOULD BE IN CONSTURCTOR!
            CultureInfo culterInfo = new CultureInfo("tr-TR"); //en-US
            Thread.CurrentThread.CurrentCulture = culterInfo;
            Thread.CurrentThread.CurrentUICulture = culterInfo;
        }


    }
}
