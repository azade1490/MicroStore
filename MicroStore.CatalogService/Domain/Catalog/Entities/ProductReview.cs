using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog.Entities
{
    public class ProductReview : Entity<Guid>
    {
        public ProductReview() { } // EF Core
        public Guid Id { get; private set; }

        public Guid ProductId { get; private set; }

        public Guid UserId { get; private set; }

        public int Rating { get; private set; }

        public string Comment { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
