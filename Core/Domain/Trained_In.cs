namespace EntityFramework_CodeFirst.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Trained_In: AuditableEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Physician { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Treatment { get; set; }

        public DateTime CertificationDate { get; set; }

        public DateTime CertificationExpires { get; set; }

        public virtual Physician Physician1 { get; set; }

        public virtual Procedure Procedure { get; set; }
    }
}
