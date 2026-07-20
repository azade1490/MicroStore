using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.Entities
{
    public class ProductImage : Entity<Guid>
    {
        public ProductImage() { } // EF Core
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public string Url { get; private set; }

        public bool IsMain { get; private set; }

        public string AltText { get; private set; }

        public int DisplayOrder { get; private set; }
    }
}
