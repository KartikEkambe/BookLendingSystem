using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLendingSystem.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage ="Required Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required Author")]

        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
        public virtual ICollection<LendingRecord> LendingRecords { get; set; }


    }
}