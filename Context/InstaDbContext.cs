using InstaSharp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InstaSharp.Context
{

    public class InstaDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Following> Following { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }
        public InstaDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static InstaDbContext Create()
        {
            return new InstaDbContext();
        }
    }
}