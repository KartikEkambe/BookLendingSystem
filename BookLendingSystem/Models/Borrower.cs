using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLendingSystem.Models
{
    public class Borrower
    {
        [Key]
        public int BorrowerId { get; set; }
        [Required(ErrorMessage ="required Name")]
        public string  Name { get;set; }
        [Required(ErrorMessage = "required Email")]
        [EmailAddress]
        public string  Email { get;set; }
        [Required(ErrorMessage ="required Phone Number")]

        public string PhoneNumber { get;set; }
        public virtual ICollection<LendingRecord> LendingRecords { get; set; }
    }
}