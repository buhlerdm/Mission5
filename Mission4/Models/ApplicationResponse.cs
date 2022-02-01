using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Mission5.Models;

namespace Mission4.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        [Required]

        // References different table
        public int CategoryID { get; set; }
        public Category Category { get; set; }


        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        
        public bool Edited { get; set; }

        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
