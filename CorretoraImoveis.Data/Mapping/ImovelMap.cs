using System.Data.Entity.ModelConfiguration;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Data.Mapping
{
    public class ImovelMap : EntityTypeConfiguration<Imovel>
    {
        public ImovelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(500);

            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);

            Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

           Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(500);

            Property(t => t.Lat)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Lng)
                .IsRequired()
                .HasMaxLength(50);

           Property(t => t.Image)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("Imovel");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Type).HasColumnName("Type");
            Property(t => t.Price).HasColumnName("Price");
            Property(t => t.Address).HasColumnName("Address");
            Property(t => t.Bathrooms).HasColumnName("Bathrooms");
            Property(t => t.Bedrooms).HasColumnName("Bedrooms");
            Property(t => t.Area).HasColumnName("Area");
            Property(t => t.Lat).HasColumnName("Lat");
            Property(t => t.Lng).HasColumnName("Lng");
            Property(t => t.DataRecord).HasColumnName("DataRecord");
            Property(t => t.Garage).HasColumnName("Garage");
            Property(t => t.SecuritySystem).HasColumnName("SecuritySystem");
            Property(t => t.AirConditioning).HasColumnName("AirConditioning");
            Property(t => t.Balcony).HasColumnName("Balcony");
            Property(t => t.OutdoorPool).HasColumnName("OutdoorPool");
            Property(t => t.Internet).HasColumnName("Internet");
            Property(t => t.Heating).HasColumnName("Heating");
            Property(t => t.TvCable).HasColumnName("TvCable");
            Property(t => t.Garden).HasColumnName("Garden");
            Property(t => t.Telephone).HasColumnName("Telephone");
            Property(t => t.FirePlace).HasColumnName("FirePlace");
            Property(t => t.Active).HasColumnName("Active");
            Property(t => t.Image).HasColumnName("Image");
        }
    }
}
