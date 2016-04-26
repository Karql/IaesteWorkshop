using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IaesteWorkshop.Models
{
    public class MovieComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        [JsonIgnore]
        public virtual Movie Movie { get; set; }

        [ForeignKey("ReplyToComment")]
        public int? ReplyToCommentId { get; set; }

        [JsonIgnore]
        public virtual MovieComment ReplyToComment { get; set; }

        [StringLength(100)]
        public string AuthorName { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string AuthorEmail { get; set; }

        public string Comment { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}