namespace HMS.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Undergo: AuditableEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Patient { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Procedure { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stay { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Date { get; set; }

        public int Physician { get; set; }

        public int? AssistingNurse { get; set; }

        public virtual Nurse Nurse { get; set; }

        public virtual Patient Patient1 { get; set; }

        public virtual Physician Physician1 { get; set; }

        public virtual Procedure Procedure1 { get; set; }

        public virtual Stay Stay1 { get; set; }
    }
}
