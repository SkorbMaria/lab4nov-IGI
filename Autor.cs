using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IGI_5.Models
{
    public class Autor
    {
        public int ID { get; set; }
        [Required]
        public string About { get; set; }
    }
}
