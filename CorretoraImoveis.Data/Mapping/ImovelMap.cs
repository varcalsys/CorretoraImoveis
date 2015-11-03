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
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Lat)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Lng)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Image)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Imovel");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Bathrooms).HasColumnName("Bathrooms");
            this.Property(t => t.Bedrooms).HasColumnName("Bedrooms");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Lat).HasColumnName("Lat");
            this.Property(t => t.Lng).HasColumnName("Lng");
            this.Property(t => t.DataRecord).HasColumnName("DataRecord");
            this.Property(t => t.Garage).HasColumnName("Garage");
            this.Property(t => t.SecuritySystem).HasColumnName("SecuritySystem");
            this.Property(t => t.AirConditioning).HasColumnName("AirConditioning");
            this.Property(t => t.Balcony).HasColumnName("Balcony");
            this.Property(t => t.OutdoorPool).HasColumnName("OutdoorPool");
            this.Property(t => t.Internet).HasColumnName("Internet");
            this.Property(t => t.Heating).HasColumnName("Heating");
            this.Property(t => t.TvCable).HasColumnName("TvCable");
            this.Property(t => t.Garden).HasColumnName("Garden");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.FirePlace).HasColumnName("FirePlace");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Image).HasColumnName("Image");
        }
    }
}
