namespace rm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lapm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idLamp { get; set; }

        [StringLength(45)]
        public string Name { get; set; }

        [StringLength(45)]
        public string Spectre { get; set; }

        public int idRidge { get; set; }

        public int? Efficacy { get; set; }

        public byte? Toggle { get; set; }

        public virtual Ridge Ridge { get; set; }
    }
}
