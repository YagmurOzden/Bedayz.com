using bedayzAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bedayzAPI.Model
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }
        //veritabanı ile ilişki kuracak hale getiriyor
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
