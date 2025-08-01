﻿using LiveTest2MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveTest2MVC.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
