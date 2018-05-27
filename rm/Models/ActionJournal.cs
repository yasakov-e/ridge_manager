namespace rm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActionJournal")]
    public partial class ActionJournal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idRecord { get; set; }

        public DateTime? Date { get; set; }

        public int? Humidity { get; set; }

        public int? Luminescence { get; set; }

        public int idAction { get; set; }

        public int idRidge { get; set; }

        public int? Temperature { get; set; }

        public virtual Action Action { get; set; }

        public virtual Ridge Ridge { get; set; }
    }
}
