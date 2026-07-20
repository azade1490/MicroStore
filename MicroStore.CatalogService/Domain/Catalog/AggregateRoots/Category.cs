using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.AggregateRoots
{
    public class Category : AggregateRoot<Guid>
    {
        public Category() { } // EF Core
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Guid? ParentCategoryId { get; private set; }
    }
}
