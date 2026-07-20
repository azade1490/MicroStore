using Microsoft.EntityFrameworkCore;

using MicroStore.InventoryService.Domain.Inventory.AggregateRoots;

using System.Reflection;

namespace MicroStore.InventoryService.Persistence.Data;
public class AppDbContext : DbContext
{
    //StartupProject مان باید پروژه ای باشد که دارای فایل Program.cs است

    //CodeFist
    //Add-Migration Init_StoreMigration -context AppDbContext
    //Add-Migration Init_StoreMigration -Context AppDbContext -StartupProject Store.Api -Project Store.Persistence
    //زمانی که StartupProject مان را Multiple startup projects تنظیم کرده باشیم

    // بدون مایگریشن هم دیتابیس را آپدیت میکند ولی ایجاد نمی کند 
    //Update-database -Context AppDbContext
    //Update-database -Context AppDbContext -StartupProject Store.Api -Project Store.Persistence
    //زمانی که StartupProject مان را Multiple startup projects تنظیم کرده باشیم

    //Drop-Database -Context AppDbContext

    //DbFirst
    //Scaffold-DbContext 'Name=ConnectionStrings:ConnectionStringStoreDb' Microsoft.EntityFrameworkCore.SqlServer
    //Scaffold-DbContext 'Name=ConnectionStrings:ConnectionStringStoreDb' Microsoft.EntityFrameworkCore.SqlServer -Tables Employee
    //Scaffold-DbContext 'Name=ConnectionStrings:ConnectionStringStoreDb' Microsoft.EntityFrameworkCore.SqlServer -Schemas dbo 
    //Scaffold-DbContext 'Name=ConnectionStrings:ConnectionStringStoreDb' Microsoft.EntityFrameworkCore.SqlServer -Tables dbo.Employee



    //// ********************------ Migration Command   ------ ********************
    ///With Terminal
    //dotnet ef migrations add Init_StoreMigration --context AppDbContext --startup-project ../Store.Api/  -o EF/Migrations

    public AppDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    public DbSet<Inventory> Inventories => Set<Inventory>();
}