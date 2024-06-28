using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creating_a_form_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace creating_a_form_backend.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Form_FormModels> Form_FormInfo { get; set; }
        public DbSet<Form_UserModels> Form_UserInfo { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}