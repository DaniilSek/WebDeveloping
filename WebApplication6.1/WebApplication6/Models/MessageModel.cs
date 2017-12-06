using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class MessageModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Topic { get; set; }

        [Required]
        [StringLength(2000)]
        public string Text { get; set; }
    }
}