using MicroStore.CatalogService.Domain.Catalog.Entities;
using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.AggregateRoots
{
    public class Product : AggregateRoot<Guid>
    {
        public Product() { } // EF Core
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public Guid CategoryId { get; private set; }

        public Guid BrandId { get; private set; }

        public bool IsActive { get; private set; }

        public ICollection<ProductImage> Images { get; private set; } = [];

        public ICollection<ProductVariant> Variants { get; private set; } = [];

        public ICollection<ProductAttribute> Attributes { get; private set; } = [];
    }
}
