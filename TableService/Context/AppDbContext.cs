using Microsoft.EntityFrameworkCore;
using TableService.Models.Models;

namespace TableService.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TableModel> TableItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableModel>().HasData(new TableModel { TableId = "T001", Capacity = 4, Available = true, Location = "Window" },
            new TableModel { TableId = "T002", Capacity = 2, Available = false, Location = "Corner" },
            new TableModel { TableId = "T003", Capacity = 6, Available = true, Location = "Center" },
            new TableModel { TableId = "T004", Capacity = 6, Available = false, Location = "Balcony" });
        }
    }

}


