﻿using Fulbolchi.Data.Models;
using Fulbolchi.Data.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fulbolchi.Data.DbContexts
{
    public  class AppDbContext : IdentityDbContext<ApiUser, Role, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options) {}
        
        public DbSet<Futbolchi> Futbolchilar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

    }
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = Guid.Parse("7e6c2d6a-dc83-4bab-b7a9-98ae31ee16ec"),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = Guid.Parse("1e6c2d6a-dc83-4bab-b7a9-98ae31ee16ec"),
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();
            builder.HasData(
                new ApiUser
                {
                    Id = Guid.Parse("7e6c2d5a-dc83-4bab-b7a9-98ae31ee16ec"),
                    FirstName = "Mansur",
                    LastName = "Xamrayev",
                    UserName = "Khmansur",
                    NormalizedUserName = "KHMANSUR",
                    PasswordHash = hasher.HashPassword(null, "Khmansur8#")
                },
                new ApiUser
                {
                    Id = Guid.Parse("7e6c2d2a-dc83-4bab-b7a9-98ae31ee16ec"),
                    FirstName = "Murod",
                    LastName = "Abdullayev",
                    UserName = "Markroft",
                    NormalizedUserName = "MARKROFT",
                    PasswordHash = hasher.HashPassword(null, "8888")
                }
            );
        }
    }

    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();
            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("7e6c2d5a-dc83-4bab-b7a9-98ae31ee16ec"),
                    RoleId = Guid.Parse("7e6c2d6a-dc83-4bab-b7a9-98ae31ee16ec")
                },
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("7e6c2d2a-dc83-4bab-b7a9-98ae31ee16ec"),
                    RoleId = Guid.Parse("1e6c2d6a-dc83-4bab-b7a9-98ae31ee16ec")
                }

            );
        }
    }
    

}
