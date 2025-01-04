using Agenda.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Dados.Repo.Config
{
    public class AgendaConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {

            builder.ToTable("TB_AGENDA");
            builder.HasKey(a => a.IdContato);

            //Configuração para IdContato
            builder.Property(a => a.IdContato)
                   .HasColumnName("ID_CONTATO")
                   .HasColumnType("INT")
                   .UseIdentityColumn();

            //COnfiguração para Nome
            builder.Property(a => a.Nome)
                   .HasColumnName("NOME")
                   .HasColumnType("VARCHAR(80)")
                   .IsRequired();

            //Configuraão de EMAIL
            builder.Property(a => a.Email)
                   .HasColumnName("EMAIL")
                   .HasColumnType("VARCHAR(100)")
                   .IsRequired();

            //Configuração de DDD
            builder.Property(a => a.Ddd)
                   .HasColumnName("DDD")
                   .HasColumnType("INT")
                   .IsRequired();

            //configuração para Telefone e Celular
            builder.Property(a => a.Telefone)
                   .HasColumnName("TELEFONE")
                   .HasColumnType("VARCHAR(15)")
                   .IsRequired(false);
            builder.Property(a => a.Celular)
                   .HasColumnName("CELULAR")
                   .HasColumnType("VARCHAR(15)")
                   .IsRequired(false);

            // Adicione um índice para Email, se for usar pesquisa baseada em email
            builder.HasIndex(a => a.Email).IsUnique();

            // Adicione um índice para DDD se for uma consulta frequente
            builder.HasIndex(a => a.Ddd);

        }
    }
}
