using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FotoEvents.Models
{
    public class EventContext : DbContext
    {

        public EventContext() : base("DefaultConnection")
        {
        }

        public DbSet<EventModel> Events { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}