using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(3)]
        public string Firstname { get; set; }
        [Required]
        [MinLength(3)]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password { get; set; }
        // [DisplayFormat(ApplyFormatInEditMode=true,DataFormatString="{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        // [DisplayFormat(ApplyFormatInEditMode=true,DataFormatString="{0:MM/dd/yyyy}")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<WeddingPlan> CreatedPlans { get; set; }
        public List<Resevation> UpcomingWeddings { get; set; }

        [NotMapped]
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string C_Password { get; set; }
    }

}