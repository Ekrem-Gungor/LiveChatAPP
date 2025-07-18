using DevBudy.CONTRACT.Repositories;
using DevBudy.DOMAIN.Entities.Concretes;
using DevBudy.PERSISTANCE.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.PERSISTANCE.Repositories.EfRepositories
{
    public class AppUserRoleRepository : Repository<AppUserRole>, IAppUserRoleRepository
    {
        public AppUserRoleRepository(DevBudyContext db) : base(db)
        {

        }
    }
}
