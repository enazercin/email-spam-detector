using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamGreenWebApp.Models;

namespace TeamGreenWebApp.Configuration
{
    public class TrashConfiguration : IEntityTypeConfiguration<Trash>
    {
        public void Configure(EntityTypeBuilder<Trash> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MailId).IsRequired();
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.IsActive);

            builder.ToTable("Trash");
        }
    }
}
