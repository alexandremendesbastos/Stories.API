using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stories.API.Data.Configurations
{
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.ToTable("Stories"); 

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd() 
                .UseIdentityColumn(1);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(60); 

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.QuantVotes)
                .IsRequired();

            builder.Property(s => s.Department)
                .IsRequired()
                .HasMaxLength(20);
        }

    }
}
