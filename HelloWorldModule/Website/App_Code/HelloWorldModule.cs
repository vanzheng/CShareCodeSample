using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HelloWorldModule
/// </summary>
public class HelloWorldModule : IHttpModule
{
	public HelloWorldModule()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Init(HttpApplication application) 
    {
        application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        application.EndRequest += (new EventHandler(this.Application_EndRequest));
    }

    private void Application_BeginRequest(object source, EventArgs e) 
    {
        HttpApplication application = (HttpApplication)source;
        HttpContext context = application.Context;
        string filePath = context.Request.FilePath;
        string fileExtension =
            VirtualPathUtility.GetExtension(filePath);
        if (fileExtension.Equals(".aspx"))
        {
            context.Response.Write("<h1><font color=red>" +
                "HelloWorldModule: Beginning of Request" +
                "</font></h1><hr>");
        }
    }

    private void Application_EndRequest(object source, EventArgs e) 
    {
        HttpApplication application = (HttpApplication)source;
        HttpContext context = application.Context;
        string filePath = context.Request.FilePath;
        string fileExtension =
            VirtualPathUtility.GetExtension(filePath);
        if (fileExtension.Equals(".aspx"))
        {
            context.Response.Write("<h1><font color=red>" +
                "HelloWorldModule: Ended of Request" +
                "</font></h1><hr>");
        }
    }

    public void Dispose() 
    {
    }
}
