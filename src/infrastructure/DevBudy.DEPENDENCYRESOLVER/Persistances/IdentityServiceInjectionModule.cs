using Autofac;
using DevBudy.DOMAIN.Entities.Concretes;
using DevBudy.PERSISTANCE.ContextClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.DEPENDENCYRESOLVER.Persistances
{
    public class IdentityServiceInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(b =>
            {
                IServiceCollection services = b.Resolve<IServiceCollection>();
                services.AddIdentityCore<AppUser>(opt =>
                {
                    opt.Password = new PasswordOptions
                    {
                        RequireDigit = false,
                        RequireLowercase = false,
                        RequireUppercase = false,
                        RequiredLength = 5,
                        RequireNonAlphanumeric = false
                    };
                    opt.SignIn.RequireConfirmedEmail = true;
                })
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<DevBudyContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>("Default");
                return services;
            }).AsSelf().InstancePerLifetimeScope();
            // Bu servis uygulama ömrü boyunca tek bir örnek olarak kullanılacak. AsSelf() ise bu servisin kendisini kaydeder, böylece DI konteyneri bu servisi çözebilir.
        }
    }
}
