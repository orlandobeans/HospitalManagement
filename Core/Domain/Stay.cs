namespace HMS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Stay")]
    public partial class Stay: AuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stay()
        {
            Undergoes = new HashSet<Undergo>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StayId { get; set; }

        public int Patient { get; set; }

        public int Room { get; set; }

        public DateTime Start { get; set; }

        public DateTime EndDateDate { get; set; }

        public virtual Patient Patient1 { get; set; }

        public virtual Room Room1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Undergo> Undergoes { get; set; }
    }
}
