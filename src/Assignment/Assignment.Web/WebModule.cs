using Assignment.Web.Models;
using Autofac;

namespace Assignment.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EmployeeCreateModel>().AsSelf();
            
            base.Load(builder);
        }
    }
}
