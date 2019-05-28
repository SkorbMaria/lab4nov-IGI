using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IGI_5.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Cypher { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Sell { get; set; }
        [Required]
        public int Fee { get; set; }
    }
}
