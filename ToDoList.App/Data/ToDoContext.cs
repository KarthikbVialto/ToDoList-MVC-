using Microsoft.EntityFrameworkCore;
using ToDoList.App.Models;

namespace ToDoList.App.Data
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<ToDoTask> Tasks { get; set; }

    }
}
