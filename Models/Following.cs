using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstaSharp.Models
{
    [Table("Following")]
    public class Following
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser UserFollowing { get; set; }

        public virtual ApplicationUser UserFollowed { get; set; }

        public DateTime Timestamp { get; set; }

        public bool Accepted { get; set; }
    }
}