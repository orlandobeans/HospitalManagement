namespace HMS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Affiliated_With: AuditableEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Physician { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Department { get; set; }

        public bool PrimaryAffiliation { get; set; }

        public virtual Department Department1 { get; set; }

        public virtual Physician Physician1 { get; set; }
    }
}
