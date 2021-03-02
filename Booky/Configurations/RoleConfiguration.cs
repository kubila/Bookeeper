using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "VoidUser",
                    NormalizedName = "VOIDUSER"
                    
                },
                new IdentityRole
                {
                    Name = "StaffUser",
                    NormalizedName = "STAFFUSER"

                },
                new IdentityRole
                {
                    Name = "AdminUser",
                    NormalizedName = "ADMINUSER"

                }
            );
        }
    }
}
