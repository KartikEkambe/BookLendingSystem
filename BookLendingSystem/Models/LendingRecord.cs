using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookLendingSystem.Models
{
    public class LendingRecord
    {
        [Key]
        public int LendingRecordId { get; set; }
        [Required]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; } 
        [Required]
        public int BorrowerId { get; set; }
        [ForeignKey("BorrowerId")]
        public virtual Borrower Borrower { get; set; }

        public DateTime DateBorrowed { get; set; }=DateTime.Now;
        public DateTime? DateReturned { get; set; }
    }
}