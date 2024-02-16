using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data
{
    public class MovieAppContext : DbContext
    {
        public MovieAppContext (DbContextOptions<MovieAppContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> User { get; set; }
        //public DbSet<MovieApp.Models.User> User { get; set; } = default!;
    }
}
