namespace EntityFramework_CodeFirst.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class On_Call: AuditableEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Nurse { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlockFloor { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlockCode { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Start { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime End { get; set; }
    }
}
