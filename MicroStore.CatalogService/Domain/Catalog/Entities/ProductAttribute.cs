using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.Entities
{
    public class ProductAttribute : Entity<Guid>
    {
        public ProductAttribute() { } // EF Core
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public string Name { get; private set; }

        public string Value { get; private set; }
    }
}
