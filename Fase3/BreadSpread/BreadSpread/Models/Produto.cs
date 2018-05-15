namespace BreadSpread.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produto")]
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            Encomenda_Produto = new HashSet<Encomenda_Produto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idProd { get; set; }

        [Required]
        [StringLength(50)]
        public string designacao { get; set; }

        [Required]
        [StringLength(500)]
        public string ingredientes { get; set; }

        [Required]
        [StringLength(500)]
        public string infoNutricional { get; set; }

        public double preco { get; set; }

        [Required]
        public byte[] imagem { get; set; }

        public double peso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda_Produto> Encomenda_Produto { get; set; }
    }
}
