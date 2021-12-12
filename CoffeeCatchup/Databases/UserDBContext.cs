using CoffeeCatchup.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCatchup.Databases
{
    public class UserDBContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }


    }
}
