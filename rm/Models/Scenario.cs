namespace rm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Scenario")]
    public partial class Scenario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Scenario()
        {
            Ridges = new HashSet<Ridge>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idScenario { get; set; }

        public int? User_creator { get; set; }

        public int? ReqHum { get; set; }

        public int? ReqLum { get; set; }

        public TimeSpan? LightOnTime { get; set; }

        public TimeSpan? LightOffTime { get; set; }

        [StringLength(45)]
        public string Name { get; set; }

        public int? Temperature { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ridge> Ridges { get; set; }
    }
}
