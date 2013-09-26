using System;
using NUnit.Framework;
using NonHttpRuntimeRazorSupport;
using TestRazorTemplates.Models;
using TestRazorTemplates.Views;
using TestRazorTemplates.Views.UsingViewStart;

namespace NonHttpRunTimeRazorSupport.Tests
{
    [TestFixture]
    public class MvcViewPageExecutorTests
    {
        private MvcViewPageExecutor pageExecutor;
        private static readonly Uri BaseUri = new Uri("http://www.example.com");

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            pageExecutor = MvcViewPageExecutor.ForAssembly(typeof(SimpleModel).Assembly);
        }

        [Test]
        public void RenderingSimpleView()
        {
            var model = new SimpleModel {Name = "Mike "};
            string content = pageExecutor.Execute<SimpleView>(model, BaseUri);
            Console.Write(content);
        }

        [Test]
        public void RenderingSimpleViewWithLayout()
        {
            var model = new SimpleModel { Name = "Mike " };
            string content = pageExecutor.Execute<SimpleViewWithLayout>(model, BaseUri);
            Console.Write(content);
        }

        [Test]
        public void RenderingSimpleViewWithLayoutSetByViewStart()
        {
            var model = new SimpleModel { Name = "Mike " };
            string content = pageExecutor.Execute<SimpleView2>(model, BaseUri);
            Console.Write(content);
        }

        [Test]
        public void RenderingSimpleViewWithPartial()
        {
            var model = new SimpleModel { Name = "Mike " };
            string content = pageExecutor.Execute<SimpleViewWithPartial>(model, BaseUri);
            Console.Write(content);
        }

        [Test]
        public void RenderingViewThatGeneratesUrls()
        {
            var model = new SimpleModel { Name = "Mike " };
            string content = pageExecutor.Execute<ViewWithLink>(model, BaseUri);
            Console.Write(content);
        }

  

//        [Test]
//        public void UsingBackground()
//        {
//            string virtualPath = typeof(SimpleViewWithLayout).GetCustomAttribute<PageVirtualPathAttribute>().VirtualPath;
//            var viewExecutor = new MvcViewPageExecutor(typeof (SimpleViewWithLayout).Assembly);
//            string result = viewExecutor.Execute(virtualPath, new SimpleModel { Name = "Mike" }, BaseUri);
//            Console.Write(result);
//
//        }
        
    }
}
