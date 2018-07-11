using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.Data.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(t => t.Id);

            ToTable("Produto");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Nome).HasColumnName("Nome").HasMaxLength(50).IsRequired();
            Property(t => t.Preco).HasColumnName("Preco").HasMaxLength(50).IsRequired();
            Property(t => t.Categoria).HasColumnName("Categoria").HasMaxLength(50).IsOptional();
        }
    }
}
