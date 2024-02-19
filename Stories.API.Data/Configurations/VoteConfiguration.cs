using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Stories.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Data.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("Votes"); // Nome da tabela no banco de dados

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .ValueGeneratedOnAdd(); // Configuração para identity

            builder.Property(v => v.StoryId)
                .IsRequired();

            builder.Property(v => v.UserId)
                .IsRequired();

            builder.Property(v => v.VoteValue)
                .IsRequired();


            // Relacionamentos
            builder.HasOne(v => v.Story)
                .WithMany(s => s.Vote)
                .HasForeignKey(v => v.StoryId);



            builder.HasOne(v => v.User)
                .WithMany(u => u.Vote)
                .HasForeignKey(v => v.UserId);

        }
    }
}
