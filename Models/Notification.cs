﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstaSharp.Models
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser ToUser { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Notification must be less than 255 characters")]
        public string Message { get; set; }

        public bool Viewed { get; set; }

        public DateTime Timestamp { get; set; }
    }
}