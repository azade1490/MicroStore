using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.Entities
{
    public class ProductTagMap : Entity<Guid>
    {
        public ProductTagMap() { } // EF Core

        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public Guid TagId { get; private set; }
    }
}
