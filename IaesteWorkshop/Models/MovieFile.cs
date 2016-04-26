using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IaesteWorkshop.Models
{
    public class MovieFile
    {
        [Key, ForeignKey("Movie")]
        public int MovieId { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public virtual Movie Movie { get; set; }    
    }
}