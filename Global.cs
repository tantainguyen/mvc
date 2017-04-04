using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VST.Controllers;

namespace VST
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ReactConfig.Configure();
        }
        /*
        protected void Application_Error(object sender, EventArgs e)
        {
            if (HttpContext.Current != null && (
                        HttpContext.Current.Request.CurrentExecutionFilePathExtension == ".cat"
                        //|| HttpContext.Current.Request.CurrentExecutionFilePathExtension == ".html"
                    )
                ) return;

            var httpContext = ((MvcApplication)sender).Context;
            var currentController = " ";
            var currentAction = " ";
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            var ex = Server.GetLastError();

            var routeData = new RouteData();
            var action = "GenericError";

            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;

                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;

                    case 500:
                        action = "InternalServerError";
                        break;

                        // others if any
                }
            }

            Response.ContentType = "text/html";
            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;

            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;
            routeData.Values["exception"] = new HandleErrorInfo(ex, currentController, currentAction);

            IController errormanagerController = new ErrorController();
            HttpContextWrapper wrapper = new HttpContextWrapper(httpContext);
            var rc = new RequestContext(wrapper, routeData);
            errormanagerController.Execute(rc);
        }
        */
    }
}
