namespace rm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ridge")]
    public partial class Ridge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ridge()
        {
            ActionJournals = new HashSet<ActionJournal>();
            Lapms = new HashSet<Lapm>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idRidge { get; set; }

        public int? Humidity { get; set; }

        public int? Luminescence { get; set; }

        public int Owner_idUser { get; set; }

        public int GroundType { get; set; }

        public int FetuseType { get; set; }

        public int idScenario { get; set; }

        public byte? Auto { get; set; }

        public int? Temperature { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActionJournal> ActionJournals { get; set; }

        public virtual Fetuse Fetuse { get; set; }

        public virtual Ground Ground { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lapm> Lapms { get; set; }

        public virtual Scenario Scenario { get; set; }

        public virtual User User { get; set; }
    }
}
