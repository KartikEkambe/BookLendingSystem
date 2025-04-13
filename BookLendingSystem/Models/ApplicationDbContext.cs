using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookLendingSystem.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext():base("DbConnection")
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<LendingRecord> LendingRecords { get; set; }
    }
}