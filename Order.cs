using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IGI_5.Models
{
    public class Order
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public Customer Customer{ get; set; }
        [Required]
        public string RecieveDate { get; set; }
        [Required]
        public string CompleteDate { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
