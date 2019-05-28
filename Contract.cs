using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IGI_5.Models
{
    public class Contract
    {
        public int ID { get; set; }
        [Required]
        public string DateStart { get; set; }
        [Required]
        public int Term { get; set; }
        [Required]
        public string DateEnd { get; set; }
        public Autor Autor { get; set; }
        public Book Book { get; set; }
    }
}
