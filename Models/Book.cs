using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JonahsBooks.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string publisher { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$")] //this is RegEx that validates the format of the isbn
        public string isbn { get; set; }
        [Required]
        public string classification { get; set; }
        [Required]
        public double price { get; set; }
    }
}
