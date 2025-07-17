using DevBudy.DOMAIN.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.PERSISTANCE.Extentions
{
    public static class UserDataSeedExt
    {
        public static void SeedUsers(ModelBuilder builder)
        {
            // Users
            string ekremUserName = "ekrem.Gungor";
            string ekremEmail = "ekrmdsgnr@gmail.com";

            string canberkUserName = "canberk.Gunduz";
            string canberkEmail = "canberk.gunduz@example.com";

            string senemUserName = "senem.Gunduz";
            string senemEmail = "gunguzsenemm@gmail.com";


            // Roles
            string developerRole = "Developer";
            string adminRole = "Admin";
            string memberRole = "Member";

            // Roles
            AppRole roleDeveloper = new()
            {
                Id = 1,
                Name = developerRole,
                NormalizedName = developerRole.ToUpperInvariant(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            AppRole roleAdmin = new()
            {
                Id = 2,
                Name = adminRole,
                NormalizedName = adminRole.ToUpperInvariant(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            AppRole roleMember = new()
            {
                Id = 3,
                Name = memberRole,
                NormalizedName = memberRole.ToUpperInvariant(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            builder.Entity<AppRole>().HasData(roleDeveloper, roleAdmin, roleMember);

            // Users
            PasswordHasher<AppUser> passwordHasher = new();

            AppUserProfile ekremProfile = new()
            {
                ID = 1,
                FirstName = "Ekrem",
                LastName = "Güngör",
            };

            AppUserProfile canberkProfile = new()
            {
                ID = 2,
                FirstName = "Canberk",
                LastName = "Gündüz",
            };

            AppUserProfile senemProfile = new()
            {
                ID = 3,
                FirstName = "Senem",
                LastName = "Gündüz",
            };

            builder.Entity<AppUserProfile>().HasData(ekremProfile, canberkProfile, senemProfile);

            AppUser userEkrem = new()
            {
                Id = 1,
                UserName = ekremUserName,
                NormalizedUserName = ekremUserName.ToUpperInvariant(),
                Email = ekremEmail,
                NormalizedEmail = ekremEmail.ToUpperInvariant(),
                PhoneNumber = "12345678910",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "123456")
            };

            AppUser userCanberk = new()
            {
                Id = 2,
                UserName = canberkUserName,
                NormalizedUserName = canberkUserName.ToUpperInvariant(),
                Email = canberkEmail,
                NormalizedEmail = canberkEmail.ToUpperInvariant(),
                PhoneNumber = "12345678910",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "1234567")
            };

            AppUser userSenem = new()
            {
                Id = 3,
                UserName = senemUserName,
                NormalizedUserName = senemUserName.ToUpperInvariant(),
                Email = senemEmail,
                NormalizedEmail = senemEmail.ToUpperInvariant(),
                PhoneNumber = "12345678910",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "12345678")
            };

            builder.Entity<AppUser>().HasData(userEkrem, userCanberk, userSenem);

            // Matching
            builder.Entity<AppUserRole>().HasData(
                new AppUserRole
                {
                    RoleId = roleDeveloper.Id,
                    UserId = userEkrem.Id,
                },
                new AppUserRole
                {
                    RoleId = roleAdmin.Id,
                    UserId = userCanberk.Id,
                },
                new AppUserRole
                {
                    RoleId = roleMember.Id,
                    UserId = userSenem.Id,
                }
            );
        }
    }
}
