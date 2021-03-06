﻿namespace PhotoSchool.Models
{
    using PhotoSchool.Data.Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Word: AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(15000, MinimumLength = 5)]
        public string Description {get; set;}

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int OrderBy { get; set; }
    }
}
