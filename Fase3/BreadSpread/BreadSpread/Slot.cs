namespace BreadSpread
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idSlot { get; set; }

        [Required]
        [StringLength(15)]
        public string horario { get; set; }

        public int idSub { get; set; }

        public virtual Subscricao Subscricao { get; set; }
    }
}
