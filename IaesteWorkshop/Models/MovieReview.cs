using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Management;
using IaesteWorkshop.Properties;

namespace IaesteWorkshop.Models
{
    public class MovieReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [StringLength(100)]
        public string ReviewerName { get; set; }
        
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string ReviewerEmail { get; set; }
        
        public string Review { get; set; }

        [Required]
        public MoviewReviewType ReviewType { get; set; }
        
        [Required]
        [Display(ResourceType = typeof(Resources), Name = "movieRating")]
        public MovieReviewRating Rating { get; set; }
    }

    public enum MoviewReviewType
    {
        Expert, Reader
    }

    public enum MovieReviewRating
    {
        Poor =2,
        BelowAverage =3,
        Average =4,
        AboveAverage=5,
        Watchable =6,
        Good = 7,
        VeryGood=9,
        Outstanging = 10
    }
}