using JovemProgramadorWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWeb.Data.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");



            builder.HasKey(t => t.id);



            builder.Property(t => t.nome).HasColumnType("varchar(50)");
            builder.Property(t => t.idade).HasColumnType("varchar(50)");
            builder.Property(t => t.matricula).HasColumnType("varchar(50)");
            builder.Property(t => t.cep).HasColumnType("varchar(50)");


        }
    }
}
