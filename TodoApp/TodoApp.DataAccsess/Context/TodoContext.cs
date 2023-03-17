using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataAccsess.Configrations;
using TodoApp.Entities.Concrete;

namespace TodoApp.DataAccsess.Context
{
    public class TodoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =DESKTOP-CH9SD0T; database = TodoDB; integrated security = true;");
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfigrations());

        }

        public DbSet<Work> Works { get; set; }
    }
}
