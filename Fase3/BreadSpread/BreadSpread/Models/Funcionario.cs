namespace BreadSpread.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Funcionario")]
    public partial class Funcionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionario()
        {
            Encomendas = new HashSet<Encomenda>();
        }

        [Key]
        public string idFunc { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime dataNasc { get; set; }

        [Required]
        [StringLength(50)]
        public string contacto { get; set; }

        [Required]
        [StringLength(100)]
        public string rua { get; set; }

        public int numPorta { get; set; }

        [Required]
        [StringLength(50)]
        public string codPostal { get; set; }

        [Required]
        [StringLength(50)]
        public string cidade { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string freguesia { get; set; }

        [Required]
        [StringLength(20)]
        public string estadoConta { get; set; }

        public bool distribuicao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda> Encomendas { get; set; }
    }
}
