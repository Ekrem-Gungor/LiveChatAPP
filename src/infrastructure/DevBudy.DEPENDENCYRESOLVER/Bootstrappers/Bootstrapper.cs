using Autofac;
using DevBudy.DEPENDENCYRESOLVER.Persistances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.DEPENDENCYRESOLVER.Bootstrappers
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(ContainerBuilder builder)
        {
            builder.RegisterModule(new PersistanceModule());
            //builder.RegisterModule(new InfrastructureDIModule());
            builder.RegisterModule(new DevBudyContextModule());
            builder.RegisterModule(new IdentityServiceInjectionModule());
        }
    }
}
