using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Configurations
{
    public class FileContainerTypeConfiguration : IEntityTypeConfiguration<FileContainer>
    {
        public void Configure(EntityTypeBuilder<FileContainer> model)
        {
            
            model.Property(x => x.Description).HasDefaultValue("No description");
            model.Property(x => x.DateOfUploaded).HasDefaultValue(DateTime.UtcNow);

           
        }
    }
}
