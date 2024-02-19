using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stories.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Stories.API.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users"); // Nome da tabela no banco de dados

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd(); // Configuração para identity

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(60); // Tamanho máximo do campo Name
        }
    }
}
