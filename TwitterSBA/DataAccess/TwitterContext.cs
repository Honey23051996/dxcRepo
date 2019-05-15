namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TwitterContext : DbContext
    {
        public TwitterContext()
            : base("name=TwitterContext")
        {
        }

        public virtual DbSet<Following> FOLLOWINGs { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Tweet> TWEETs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Following>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<Following>()
                .Property(e => e.followingid)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.full_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Email_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.FOLLOWINGs)
                .WithRequired(e => e.PERSON)
                .HasForeignKey(e => e.userid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.FOLLOWINGs1)
                .WithRequired(e => e.PERSON1)
                .HasForeignKey(e => e.followingid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TWEETs)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .Property(e => e.Useridd)
                .IsUnicode(false);

            modelBuilder.Entity<Tweet>()
                .Property(e => e.usermessage)
                .IsUnicode(false);
        }
    }
}
