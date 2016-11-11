namespace EF6CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Model : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EF6CodeFirst.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public Model()
            : base("name=Model")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Pessoa> Pessoa { get; set; }
    }
    
    [Table("Pessoa")]
    public partial class Pessoa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}