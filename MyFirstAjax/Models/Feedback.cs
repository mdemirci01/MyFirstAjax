using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAjax.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [StringLength(100)]
        [Required]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [StringLength(100)]
        [Required]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Mesaj")]
        public string Message { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; }
    }
}
