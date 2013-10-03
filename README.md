NonHttpRunTimeRazorSupport
==============================================

Introduction
------------

NonHttpRunTimeRazorSupport demonstrates one way to use ASP.Net MVC Razor views to render content outside of the context of a running ASP.Net application. It provides full support for layouts, _ViewStart files, partials, HtmlHelper, Urlhelper etc.

It uses [RazorGenerator](http://razorgenerator.codeplex.com/) precompiled templates, together with some infrastructure to support execution of WebViewPage template code outside of a web app. 

See my introductory [blog post](http://www.danmalcolm.com/2013/10/razor-views-outside-of-web-application.html) for further background.

How to Use
----------

This project is currently intended as a demonstration of how to do things and is not packaged up as a distributable library. Have a look at the code. If it does what you need and you like it, copy the bits you need into your project. 

Here are the steps that you'd need to take to add the necessary infrastructure to your project and render content using templates in a dedicated project containing Razor views:

1. Install RazorGenerator from the VS extension gallery - (see [RazorGenerator installation instructions](http://razorgenerator.codeplex.com/) for further details)

2. Copy the source code from the main  [NonHttpRunTimeRazorSupport](https://github.com/danmalcolm/NonHttpRunTimeRazorSupport/tree/master/src/NonHttpRunTimeRazorSupport) class library into your solution and modify the namespaces / references accordingly

3. Create a new ASP.Net MVC web application project to store your Razor views. Although you won't actually run the project as a web app, the web.config files present in this type of project will provide useful Intellisense support when editing the views in Visual Studio. 

4. Add your views to this project. For each view, open the "Properties" panel and set the "Custom Tool" property to "RazorGenerator". As shown in the (EmailDemoTemplates)[https://github.com/danmalcolm/NonHttpRunTimeRazorSupport/tree/master/src/EmailDemoTemplates] project, it might make sense to include the model classes in your views projectalso.

5. Use the following code in your application to render a view:

    var renderer = ViewRenderer.ForAssemblyOf<SimpleModel>();
    var model = new SimpleModel {Name = "Mike "};
    string content = renderer.RenderView<SimpleView>(model, new Uri("http://www.example.com"));
    
  Alternatively, you can specify the path to the view:
             
    string content = renderer.RenderView("~/Views/SimpleView.cshtml", model, new Uri("http://www.example.com"));

Development
-----------
If you want to experiment / play around:

- Clone the repository or [download the solution](https://github.com/danmalcolm/NonHttpRunTimeRazorSupport/archive/master.zip) from Github if you're not familiar with git
- Open the solution in Visual Studio
- Run the tests or set EmailDemo as your startup project and hit F5.

The solution was developed with Visual Studio 2012. You'll need to enable [NuGet Package Restore](http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages) to build.


Next
----

I plan to add a NuGet package once I've got some further feedback from using this mechanism on a wider range of projects. 

Licence
-------

This is free and unencumbered software released into the public domain. See [UNLICENSE.txt](https://github.com/danmalcolm/NonHttpRunTimeRazorSupport/blob/master/UNLICENSE.txt) for full terms.

Please be aware that RazorGenerator is [licensed separately](http://razorgenerator.codeplex.com/license).
