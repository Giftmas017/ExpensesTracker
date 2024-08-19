using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoviesRental.Models
{
    
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        public decimal Value { get; set; }
        [Required]
        public string Description { get; set; }

    }
}