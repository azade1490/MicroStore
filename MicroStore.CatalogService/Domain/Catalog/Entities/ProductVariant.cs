using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.Entities
{
    public class ProductVariant : Entity<Guid>
    {
        public ProductVariant() { } // EF Core
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public string SKU { get; private set; }

        public string Color { get; private set; }

        public string Size { get; private set; }

        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }
    }
}
