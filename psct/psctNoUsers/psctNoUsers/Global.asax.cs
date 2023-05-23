﻿using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace psct;

public class MvcApplication : System.Web.HttpApplication
{
    protected void Application_Start( )
    {
        AreaRegistration.RegisterAllAreas( );
        FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
        RouteConfig.RegisterRoutes( RouteTable.Routes );
        BundleConfig.RegisterBundles( BundleTable.Bundles );
    }

    protected void Application_BeginRequest( object sender, EventArgs e )
    {
        if ( Request.Url.Host.StartsWith( "www." ) || Request.Url.IsLoopback ) return;
        UriBuilder builder = new( Request.Url )
                             {
                                 Host = "www." + Request.Url.Host
                             };
        Response.StatusCode = 301;
        Response.AddHeader( "Location", builder.ToString( ) );
        Response.End( );
    }
}