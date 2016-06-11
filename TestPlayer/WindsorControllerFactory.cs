using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using System.Reflection;
using Castle.Core;
using System.Web.Routing;
 

namespace TestPlayer
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        WindsorContainer container;

        public WindsorControllerFactory()
        {
            container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

//            Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule

            container.Register(AllTypes
                .FromThisAssembly()
                .BasedOn<IController>()
                .If(Component.IsInSameNamespaceAs<Controllers.TestsController>())
                .If(t => t.Name.EndsWith("Controller"))
                .Configure(c => c.LifeStyle.Transient.Named(c.Implementation.Name)));


            //var ControllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
            //                      where typeof(IController).IsAssignableFrom(t)
            //                      select t;

            //foreach (Type t in ControllerTypes)
            //{
            //    container.AddComponentWithLifestyle(t.FullName, t, LifestyleType.Transient);
            //}
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)container.Resolve(controllerType);

        }

    }
}