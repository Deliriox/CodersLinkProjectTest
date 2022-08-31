using Autofac;
using AutoMapper;
using Domain.IManager;
using Domain.IRepository;
using Domain.Manager;
using Domain.Models;
using Domain.Repository;

namespace CodersLinkProjectTest
{
    public class MyApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //     builder.RegisterType<SecuritySettings>()
            //.As<SecuritySettings>();
            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .SingleInstance();


            builder.RegisterType<UserManager>().As<IUserManager>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
        }
    }
}
