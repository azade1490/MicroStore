using MicroStore.CatalogService.Domain.Common;

namespace MicroStore.CatalogService.Domain.Catalog
{
    public static class ProductErrors
    {
        public static readonly Error NotFound =
            Error.NotFound("Product.NotFound", "The product was not found.");

        public static readonly Error AlreadyPaid =
            Error.Conflict("Product.AlreadyPaid", "The product has already been paid.");

        public static readonly Error InvalidState =
            Error.Validation("Product.InvalidState", "The product state is invalid."); 

        public static readonly Error ArgumentOutOfRange =
            Error.ArgumentOutOfRange("Product.ArgumentOutOfRange", "The product argument out of range.");
    }
}
