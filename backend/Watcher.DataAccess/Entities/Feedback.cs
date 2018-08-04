﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Watcher.DataAccess.Entities
{
    public class Feedback : Entity<int>
    {
        public override int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? ResponseId { get; set; }
        public Response Response { get; set; }
    }
}
