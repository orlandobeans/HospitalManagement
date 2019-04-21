namespace HMS.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Appointment")]
    public partial class Appointment: AuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment()
        {
            Prescribes = new HashSet<Prescribe>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppointmentId { get; set; }

        public int Patient { get; set; }

        public int? PrepNurse { get; set; }

        public int Physician { get; set; }

        public DateTime Start { get; set; }

        public DateTime EndDateDate { get; set; }

        [Required]
        public string ExaminationRoom { get; set; }

        public virtual Patient Patient1 { get; set; }

        public virtual Physician Physician1 { get; set; }

        public virtual Nurse Nurse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescribe> Prescribes { get; set; }
    }
}
