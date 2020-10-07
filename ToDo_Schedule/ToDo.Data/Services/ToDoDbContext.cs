using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;

namespace ToDo.Data.Services
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<TaskDetails> Tasks { get; set; }

    }
}
