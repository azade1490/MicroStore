using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.AggregateRoots
{
    public class Brand : AggregateRoot<Guid>
    {
        public Brand() { } // EF Core
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string? Description { get; private set; }

        public string? LogoUrl { get; private set; }
    }
}
