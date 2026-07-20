using MicroStore.InventoryService.Domain.Common;

namespace MicroStore.InventoryService.Domain.Inventory.AggregateRoots;
public sealed class Inventory : AggregateRoot<Guid>
{
    private Inventory() { } // EF Core

    public Inventory(Guid productId, int quantity)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        AvailableQuantity = quantity;
        ReservedQuantity = 0;
    }

    public Guid ProductId { get; private set; }

    public int AvailableQuantity { get; private set; }

    public int ReservedQuantity { get; private set; }

    public int TotalQuantity => AvailableQuantity + ReservedQuantity;

    public bool IsAvailable(int quantity)
        => AvailableQuantity >= quantity;

    public void Reserve(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        if (AvailableQuantity < quantity)
            throw new InvalidOperationException("Insufficient inventory.");

        AvailableQuantity -= quantity;
        ReservedQuantity += quantity;
    }

    public void Release(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        if (ReservedQuantity < quantity)
            throw new InvalidOperationException("Reserved quantity is insufficient.");

        ReservedQuantity -= quantity;
        AvailableQuantity += quantity;
    }

    public void Commit(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        if (ReservedQuantity < quantity)
            throw new InvalidOperationException("Reserved quantity is insufficient.");

        ReservedQuantity -= quantity;
    }

    public void Restock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        AvailableQuantity += quantity;
    }
}