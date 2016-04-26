using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IaesteWorkshop.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string TrailerUrl { get; set; }

        [Required]
        public string Cast { get; set; }

        [Required]
        public string Direction { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Time)]
        public TimeSpan Duration { get; set; }
    }
}