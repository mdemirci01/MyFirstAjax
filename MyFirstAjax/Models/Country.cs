using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAjax.Models
{
    public class Country
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        [Display(Name = "Ülke Adı")]
        public string Name { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
