namespace BreadSpread
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscricao")]
    public partial class Subscricao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscricao()
        {
            Clientes = new HashSet<Cliente>();
            Slots = new HashSet<Slot>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idSub { get; set; }

        [Required]
        [StringLength(50)]
        public string designacao { get; set; }

        public double custo { get; set; }

        [Required]
        [StringLength(200)]
        public string plano_ent { get; set; }

        [Required]
        [StringLength(50)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
