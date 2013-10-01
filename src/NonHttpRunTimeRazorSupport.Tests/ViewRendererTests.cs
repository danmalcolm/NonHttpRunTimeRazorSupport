using System;
using NUnit.Framework;
using NonHttpRuntimeRazorSupport;
using TestRazorTemplates.Models;
using TestRazorTemplates.Views;
using TestRazorTemplates.Views.UsingViewStart;

namespace NonHttpRunTimeRazorSupport.Tests
{
    [TestFixture]
    public class ViewRendererTests
    {
        private ViewRenderer renderer;
        private static readonly Uri BaseUri = new Uri("http://www.example.com");

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            renderer = ViewRenderer.ForAssemblyOf<SimpleModel>();
        }

        [Test]
        public void RenderingSimpleView()
        {
            var model = new SimpleModel {Name = "Mike "};
            string content = renderer.RenderView<SimpleView>(model, BaseUri);
            Console.Write(content);
        }

        [Test]
        public void RenderingSimpleViewWithLayout()
        {
            var model = new SimpleModel { Name = "Mike " };
            string content = renderer.RenderView<SimpleViewWithLayout>(model, BaseUri);
            Console.Write(content);
        }

        [Test]
        public void RenderingSimpleViewWithLayoutSetByViewStart()
        {
            var model = new SimpleModel { Name = "Mike " };
            string content = renderer.RenderView<SimpleView2>(model, BaseUri);
            Console.Write(content);
        }

        [Test]
        public void RenderingSimpleViewWithPartial()
        {
            var model = new SimpleModel { Name = "Mike " };
            string content = renderer.RenderView<SimpleViewWithPartial>(model, BaseUri);
            Console.Write(content);
        }

        [Test]
        public void RenderingViewThatGeneratesUrls()
        {
            var model = new SimpleModel { Name = "Mike " };
            string content = renderer.RenderView<ViewWithLink>(model, BaseUri);
            Console.Write(content);
        }

  

//        [Test]
//        public void UsingBackground()
//        {
//            string virtualPath = typeof(SimpleViewWithLayout).GetCustomAttribute<PageVirtualPathAttribute>().VirtualPath;
//            var viewExecutor = new ViewRenderer(typeof (SimpleViewWithLayout).Assembly);
//            string result = viewExecutor.RenderView(virtualPath, new SimpleModel { Name = "Mike" }, BaseUri);
//            Console.Write(result);
//
//        }
        
    }
}
