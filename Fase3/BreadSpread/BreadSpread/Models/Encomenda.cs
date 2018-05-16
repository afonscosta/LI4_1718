namespace BreadSpread.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Encomenda")]
    public partial class Encomenda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Encomenda()
        {
            Encomenda_Produto = new HashSet<Encomenda_Produto>();
        }

        [Key]
        public int idEnc { get; set; }

        public int idCli { get; set; }

        [Column(TypeName = "date")]
        public DateTime dataEnt { get; set; }

        public double custo { get; set; }

        [Required]
        [StringLength(50)]
        public string estado { get; set; }

        public int idFunc { get; set; }

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

        [StringLength(500)]
        public string obs { get; set; }

        [Required]
        [StringLength(50)]
        public string freguesia { get; set; }

        [Required]
        [StringLength(10)]
        public string tipoEnc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dataPag { get; set; }

        [StringLength(50)]
        public string modoPag { get; set; }

        public byte[] fatura { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda_Produto> Encomenda_Produto { get; set; }
    }
}
