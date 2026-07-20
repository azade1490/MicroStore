using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.Entities
{
    public class ProductTag : Entity<Guid>
    {
        public ProductTag() { } // EF Core
        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}
