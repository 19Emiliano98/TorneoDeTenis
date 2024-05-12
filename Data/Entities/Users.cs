using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? refreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }

    public class UserConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").IsRequired();
            builder.Property(x => x.refreshToken).HasColumnName("RefeshToken");
            builder.Property(x => x.RefreshTokenExpiration).HasColumnName("RefeshTokenExpiration");

        }
    }
}
