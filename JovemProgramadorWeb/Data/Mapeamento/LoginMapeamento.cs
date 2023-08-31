using JovemProgramadorWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWeb.Data.Mapeamento
{
    public class LoginMapeamento : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");



            builder.HasKey(t => t.id);



            builder.Property(t => t.email).HasColumnType("varchar(100)");
            builder.Property(t => t.senha).HasColumnType("varchar(50)");
         


        }
    }
}


