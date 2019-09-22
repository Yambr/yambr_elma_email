using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EleWise.ELMA.Web.Mvc.Controllers;
using Newtonsoft.Json;

namespace Yambr.ELMA.Email.Web.Controllers
{
    public class BaseApiController : BaseController
    {
        //
        // GET: /BaseApi/

        public new ActionResult Json(object data)
        {
            return new JsonNetActionResult(data);
        }

        public class JsonNetActionResult : ActionResult
        {
            public Object Data { get; private set; }

            public JsonNetActionResult(Object data)
            {
                this.Data = data;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.Write(JsonConvert.SerializeObject(Data));
            }
        }
    }
}
