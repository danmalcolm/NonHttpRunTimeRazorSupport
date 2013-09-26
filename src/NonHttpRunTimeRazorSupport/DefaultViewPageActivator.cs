using System;
using System.Web.Mvc;

namespace NonHttpRunTimeRazorSupport
{
    internal class ViewPageActivator : IViewPageActivator
    {
        public object Create(ControllerContext controllerContext, Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
