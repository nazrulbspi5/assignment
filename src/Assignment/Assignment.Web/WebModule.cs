using Assignment.Web.Models;
using Autofac;

namespace Assignment.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EmployeeCreateModel>().AsSelf();
            builder.RegisterType<EmployeeListModel>().AsSelf();
            builder.RegisterType<EmployeeSearch>().AsSelf();

            base.Load(builder);
        }
    }
}
