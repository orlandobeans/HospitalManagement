namespace EntityFramework_CodeFirst.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Prescribe
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Physician { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Patient { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Medication { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Date { get; set; }

        public int? Appointment { get; set; }

        [Required]
        public string Dose { get; set; }

        public virtual Appointment Appointment1 { get; set; }

        public virtual Medication Medication1 { get; set; }

        public virtual Patient Patient1 { get; set; }

        public virtual Physician Physician1 { get; set; }
    }
}
