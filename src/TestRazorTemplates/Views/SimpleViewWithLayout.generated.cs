﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestRazorTemplates.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\SimpleViewWithLayout.cshtml"
    using TestRazorTemplates.Html;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/SimpleViewWithLayout.cshtml")]
    public partial class SimpleViewWithLayout : System.Web.Mvc.WebViewPage<TestRazorTemplates.Models.SimpleModel>
    {
        public SimpleViewWithLayout()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\SimpleViewWithLayout.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\nIn Main View: ");

            
            #line 6 "..\..\Views\SimpleViewWithLayout.cshtml"
         Write(Model.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\nBefore Partial\r\n");

            
            #line 8 "..\..\Views\SimpleViewWithLayout.cshtml"
Write(Html.Partial("SimplePartial", new { Name = "Partial" }));

            
            #line default
            #line hidden
WriteLiteral("\r\nAfter Partial\r\nUrl: ");

            
            #line 10 "..\..\Views\SimpleViewWithLayout.cshtml"
Write(Url.Content("~/images/logo.gif"));

            
            #line default
            #line hidden
WriteLiteral("\r\nAbsolute Url: ");

            
            #line 11 "..\..\Views\SimpleViewWithLayout.cshtml"
         Write(Url.Absolute("~/images/logo.gif"));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
