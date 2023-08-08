using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamGreenWebApp.Models;

namespace TeamGreenWebApp.Configuration
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MailHeader).HasMaxLength(700);
            builder.Property(x => x.MailContent).HasMaxLength(700);
            //builder.Property(x => x.SenderId).IsRequired();
            //builder.Property(x => x.ReciverId).IsRequired();
            builder.Property(x => x.IsSpam);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.IsActive);


            builder.ToTable("Mail");
        }
    }
}
