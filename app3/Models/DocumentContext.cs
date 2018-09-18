using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace app3.Models
{
    public class DocumentContext : DbContext
    {
        public DocumentContext()
            : base("DocumentConnection")
        {
            Database.SetInitializer<DocumentContext>(new CreateDatabaseIfNotExists<DocumentContext>());
        }
        public DbSet<Document> Docs { get; set; }
    }
}