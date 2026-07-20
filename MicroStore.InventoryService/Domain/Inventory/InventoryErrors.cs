using MicroStore.InventoryService.Domain.Common;

namespace MicroStore.InventoryService.Domain.Inventory
{
    public static class InventoryErrors
    {
        public static readonly Error NotFound =
            Error.NotFound("Inventory.NotFound", "The inventory was not found.");

        public static readonly Error AlreadyPaid =
            Error.Conflict("Inventory.AlreadyPaid", "The inventory has already been paid.");

        public static readonly Error InvalidState =
            Error.Validation("Inventory.InvalidState", "The inventory state is invalid."); 

        public static readonly Error ArgumentOutOfRange =
            Error.ArgumentOutOfRange("Inventory.ArgumentOutOfRange", "The inventory argument out of range.");
    }
}
