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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idRidge { get; set; }

        public int? Humidity { get; set; }

        public int? Luminescence { get; set; }

        public int Owner_idUser { get; set; }

        public int GroundType { get; set; }

        public int FetuseType { get; set; }

        public virtual Fetuse Fetuse { get; set; }

        public virtual Ground Ground { get; set; }

        public virtual User User { get; set; }
    }
}
