using System;
using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.Common {
    public abstract class ModelBase {

        [Key]
        public int Id { get; protected set; }

        [MaxLength(44)]
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(44)]
        public string LastModifiedBy { get; set; }

        public DateTime? UpdateddAt { get; set; }
    }
}
