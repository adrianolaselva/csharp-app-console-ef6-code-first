namespace EF6CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Collections;
    using System.Collections.Generic;

    public class ModelContext : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EF6CodeFirst.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public ModelContext()
            : base("name=ModelContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ModelContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Profile>();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<PersonLog> PersonLog { get; set; }
    }
    
    [Table("Person")]
    public partial class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Column("ProfileId")]
        public Profile Perfil { get; set; }

        public ICollection<PersonLog> PersonLogs { get; set; }

    }

    [Table("Profile")]
    public partial class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    [Table("PersonLog")]
    public partial class PersonLog
    {
        [Key]
        public int Id { get; set; }
        
        [Column("PersonId")]
        public Person Person { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }

}