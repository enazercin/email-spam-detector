using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamGreenWebApp.Models;

namespace TeamGreenWebApp.Configuration
{
    public class ReciverConfiguration : IEntityTypeConfiguration<Reciver>
    {
        public void Configure(EntityTypeBuilder<Reciver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserId);
            builder.Property(x => x.MailAddress).HasMaxLength(50);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.IsActive);


            builder.ToTable("Reciver");
        }
    }
}
