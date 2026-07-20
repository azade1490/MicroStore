using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.Entities
{
    public class ProductSpecification : Entity<Guid>
    {
        public ProductSpecification() { } // EF Core
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public int SortOrder { get; private set; }
    }
}
