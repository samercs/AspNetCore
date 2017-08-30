using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCore.Entity.Enum;
using AspNetCore.Entity.Idintity;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Entity
{
    public class User: IdentityUser<int>
    {
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime CreatedUtc { get; set; }

        public DateTime? ModifiedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        
    }
}
